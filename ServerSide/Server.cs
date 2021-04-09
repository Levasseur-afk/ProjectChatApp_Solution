using Communication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerSide
{
    public class Server
    {
        private int port;
        // Rendre dicoUsers Serializable
        private Dictionary<string, string> dicoUsers;
        private Dictionary<string, TcpClient> dicoUsersOnline;
        private Dictionary<string, List<TcpClient>> dicoTopics;
        private Dictionary<string, List<TcpClient>> dicoPriv;


        public Server(int port)
        {
            this.port = port;
            dicoUsersOnline = new Dictionary<string, TcpClient>();

            // Initialization from a file
            this.dicoUsers = new Dictionary<string, string>();
            loadUsers();
            addNewUser("Julie", "0");
            addNewUser("Seb", "0");
            

            // Initialization manually
            dicoTopics = new Dictionary<string, List<TcpClient>>();
            dicoTopics.Add("Chansons", new List<TcpClient>());
            dicoTopics.Add("Voyages", new List<TcpClient>());

            dicoPriv = new Dictionary<string, List<TcpClient>>();

            start();
        }

        public void start()
        {
            try
            {
                TcpListener serverSocket = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), port);
                serverSocket.Start();
                Console.WriteLine("[SERVER] Started");
                while (true)
                {
                    TcpClient client = serverSocket.AcceptTcpClient();
                    Console.WriteLine("[SERVER] New connection established");
                    new Thread(new SocketController(client, this).chat).Start();
                }
            }
            catch (SocketException)
            {
                Console.WriteLine("[SERVER] Already started");
            }

        }
        public bool createTopic(string name)
        {
            try
            {
                dicoTopics.Add(name, new List<TcpClient>());
                return true;
            }
            catch (System.ArgumentException)
            {
                return false;
            }
        }

        public List<TcpClient> getListOfUsersOfTopic(string nameDisc)
        {
            foreach (KeyValuePair<string, List<TcpClient>> disc in this.dicoTopics)
            {
                if (disc.Key.Equals(nameDisc))
                {
                    return disc.Value;
                }
            }
            return null;
        }
        public List<TcpClient> getListOfUsersOfPriv(string nameDisc)
        {
            String[] person = nameDisc.Split('/');
            foreach (KeyValuePair<string, List<TcpClient>> disc in this.dicoPriv)
            {
                if (disc.Key.Equals(person[0] + "/" + person[1]) || disc.Key.Equals(person[1] + "/" + person[0]))
                {
                    return disc.Value;
                }
            }
            return null;
        }
        public bool addNewUser(string login, string password)
        {
            bool valid = true;
            foreach (KeyValuePair<string, string> user in this.dicoUsers)
            {
                if (user.Key.Equals(login))
                {
                    valid = false;
                }
            }
            if (valid)
            {
                this.dicoUsers.Add(login, password);
                
                saveUsers();
            }
            return valid;
        }
        public bool validCredentials(String login, String password)
        {
            bool valid = false;
            foreach (KeyValuePair<string, string> user in this.dicoUsers)
            {
                if (user.Key.Equals(login) && user.Value.Equals(password))
                {
                    valid = true;
                }
            }
            return valid;
        }
        public void addSocketInDisc(string key, TcpClient socket)
        {
            getListOfUsersOfTopic(key).Add(socket);
        }
        public String shareTopicsUsingSocket()
        {
            String s = "";
            foreach (KeyValuePair<string, List<TcpClient>> disc in this.dicoTopics)
            {
                s += "#" + disc.Key;
            }
            s = s.Remove(0, 1);
            return s;
        }
        public String shareUsersUsingSocket()
        {
            String s = "";
            foreach (KeyValuePair<string, TcpClient> disc in this.dicoUsersOnline)
            {
                s += "#" + disc.Key;
            }
            s = s.Remove(0, 1);
            return s;
        }
        public void createPrivDisc(String userHost,TcpClient socketHost, String userCalled)
        {
            // To not be able to start 2 private discussions with the same person
            if (!(this.dicoPriv.ContainsKey(userHost + "/" + userCalled) || this.dicoPriv.ContainsKey(userCalled + "/" + userHost)))
            {
                // Prepare the list of socket concerned by the private discussion
                List<TcpClient> temp = new List<TcpClient>();
                temp.Add(socketHost);

                //Create the private Discussion on the server
                this.dicoPriv.Add(userHost + "/" + userCalled, temp);

                //Tell the user Called that this userHost starts a private discussion with him
                Net.sendMsg(findMainSocketUser(userCalled).GetStream(), "Priv#" + userHost);
            }
        }
        public void joinPrivDisc(String userHost, String userCalled, TcpClient socketCalled)
        {
            foreach (KeyValuePair<string, List<TcpClient>> element in this.dicoPriv)
            {
                if (element.Key.Equals(userHost + "/" + userCalled) || element.Key.Equals(userCalled + "/" + userHost))
                {
                    element.Value.Add(socketCalled);
                }
            }
        }
        public void addUserOnline(TcpClient socket, String login)
        {
            this.dicoUsersOnline.Add(login, socket);
        }

        public TcpClient findMainSocketUser(String login)
        {
            foreach (KeyValuePair<string, TcpClient> element in this.dicoUsersOnline)
            {
                if (element.Key.Equals(login))
                {
                    return element.Value; 
                }
            }
            return null;
        }
        public void leaveTopic(string key, TcpClient socket)
        {
            getListOfUsersOfTopic(key).Remove(socket);
        }
        public void leavePriv(String name1, String name2, TcpClient socket)
        {
            foreach (KeyValuePair<string, List<TcpClient>> element in this.dicoPriv)
            {
                if (element.Key.Equals(name1 + "/" + name2) || element.Key.Equals(name2 + "/" + name1))
                {
                    element.Value.Remove(socket);
                    if(element.Value.Count == 0)
                    {
                        this.dicoPriv.Remove(element.Key);
                    }
                    break;
                }
            }
        }

        public void disconnect(string login)
        {
            this.dicoUsersOnline.Remove(login);
        }
        public void saveUsers()
        {
            Serialize_Deserialize.SerializeUsers(this.dicoUsers);
        }
        public void loadUsers()
        {
            try
            {
                this.dicoUsers = Serialize_Deserialize.DeserializeUsers();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("[SERVER] No file users.out was found in temp");
            }
        }
        public String displayUsers()
        {
            String temp = "[USERS] ";
            foreach(KeyValuePair<string, TcpClient> element in this.dicoUsersOnline)
            {
                temp += element.Key + " // ";
            }
            return temp;
        }
        public String displayTopics()
        {
            String temp = "[TOPICS] \r\n";
            foreach(KeyValuePair<string, List<TcpClient>> element in this.dicoTopics)
            {
                temp += "[" +element.Key +"] => users : " + Convert.ToString(element.Value.Count) + "\r\n";
            }
            return temp;
        }
        public String displayPriv()
        {
            String temp = "[PRIV] ";
            foreach (KeyValuePair<string, List<TcpClient>> element in this.dicoPriv)
            {
                temp += element.Key + " // ";
            }
            return temp;
        }
    }
}
