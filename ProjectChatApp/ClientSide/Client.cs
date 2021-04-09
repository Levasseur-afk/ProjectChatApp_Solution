using Communication;
using ProjectChatApp.Launcher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectChatApp.ClientSide
{
    class Client
    {
        private Dictionary<string, TcpClient> dicoTopics;
        private Dictionary<string, TcpClient> dicoPriv;
        private List<Chat> chats;
        private String _login;
        private Thread privDisc;
        private String test;
        private Rgb color;

        public Client()
        {
            this.dicoTopics = new Dictionary<string, TcpClient>();
            this.dicoPriv = new Dictionary<string, TcpClient>();
            this.chats = new List<Chat>();
            this.color = Program.rdmColor();
            addSocket("Person", new TcpClient("127.0.0.1", 8976));
        }
        public void startPrivListener()
        {
            addPrivSocket("PrivDisc", new TcpClient("127.0.0.1", 8976));
            Net.sendMsg(Program.client.getPrivByKey("PrivDisc").GetStream(), "addNewPrivSocket#" + this._login);
            this.privDisc = new Thread(() =>
            {
                while (true)
                {
                    String[] m = Net.rcvMsg(Program.client.getPrivByKey("PrivDisc").GetStream()).Split('#');
                    if (m[0].Equals("Priv"))
                    {
                        this.test = m[1];
                        // Add socket in Client list of disc joined
                        addPrivSocket(m[1], new TcpClient("127.0.0.1", 8976));

                        //Identify the socket on the server
                        Net.sendMsg(Program.client.getPrivByKey(m[1]).GetStream(), "joinPriv#" + m[1] + "#" + this._login);

                        //Create the Chat
                        Application.Run(new Chat(this.test, false));                            
                    }                
                }
            });
            privDisc.Start();
        }
        /*
        public void Run()
        {
                Chat c =
                addChat(c);
                c.Show();
        }
        */
        public String Login
        {
            get
            {
                return this._login;
            }
            set
            {
                this._login = value;
            }
        }
        public TcpClient getTopicByKey(string key)
        {
            foreach (KeyValuePair<String, TcpClient> e in this.dicoTopics)
            {
                if (e.Key.Equals(key))
                {
                    return e.Value;
                }
            }
            return null;
        }
        public TcpClient getPrivByKey(string key)
        {
            foreach (KeyValuePair<String, TcpClient> e in this.dicoPriv)
            {
                if (e.Key.Equals(key))
                {
                    return e.Value;
                }
            }
            return null;
        }
        public void addSocket(string key, TcpClient socket)
        {
            this.dicoTopics.Add(key, socket);
        }
        public void addPrivSocket(string key, TcpClient socket)
        {
            this.dicoPriv.Add(key, socket);
        }
        public void removeTopicByKey(string key)
        {
            getTopicByKey(key).Close();
            this.dicoTopics.Remove(key);
        }
        public void removePrivByKey(string key)
        {
            getPrivByKey(key).Close();
            this.dicoPriv.Remove(key);
        }
        public void leaveAll()
        {
            foreach (KeyValuePair<String, TcpClient> e in this.dicoTopics)
            {
                // I want to leave all topics but not disconnect Client yet
                if (!e.Key.Equals("Person"))
                {
                    //Send instruction to remove the socket of the topic from the server
                    Net.sendMsg(e.Value.GetStream(), "Leave#" + e.Key + "#topic");
                    //Close the socket
                    e.Value.Close();
                }
            }
            foreach (KeyValuePair<String, TcpClient> e in this.dicoPriv)
            {
                // I want to leave all private discussions
                //Send instruction to remove the socket of the private discussion from the server
                Net.sendMsg(e.Value.GetStream(), "Leave#" + e.Key + "#priv");
                //Close the socket
                e.Value.Close();  
            }
            this.privDisc.Abort();
        }
        public void closeThreadsFromChats()
        {
            try
            {
                foreach (Chat c in this.chats)
                    {
                        c.getChat().Abort();
                    }
            }
            catch (ThreadAbortException)
            {
                // Nothing to do 
            }
        }
        public void addChat(Chat c)
        {
            this.chats.Add(c);
        }
        public void removeChat(Chat c)
        {
            this.chats.Remove(c);
        }
        public bool validJoin(String topic)
        {
            bool valid = true;
            foreach(KeyValuePair<String, TcpClient> e in this.dicoTopics)
            {
                if (e.Key.Equals(topic))
                {
                    valid = false;
                }
            }
            return valid;
        }
        public bool validPrivDisc(String user)
        {
            bool valid = true;
            foreach (KeyValuePair<String, TcpClient> e in this.dicoPriv)
            {
                if (e.Key.Equals(user))
                {
                    valid = false;
                }
            }
            return valid;
        }
        public Rgb getColor()
        {
            return this.color;
        }
    }
}
