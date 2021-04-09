using Communication;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ServerSide
{
    public class SocketController
    {
        private TcpClient _socket;
        private bool logged;
        private string login;
        private Server server;

        public SocketController(TcpClient socket, Server server)
        {
            this.server = server;
            this._socket = socket;
            this.logged = false;
        }

        public void chat()
        {
            while (true)
            {
                try
                {
                    // This line can create InvalidOperationException when closing _socket
                    String[] message = Net.rcvMsg(_socket.GetStream()).Split('#');
                    Console.WriteLine("[SOCKET] Expression received"); 
                    // read expression

                    if (message[0].Equals("Login"))
                    {
                        if (!this.logged)
                        {
                            this.login = message[1];
                            string password = message[2];
                            if (this.server.validCredentials(this.login, password))
                            {
                                this.logged = true;
                                Net.sendMsg(_socket.GetStream(), "Logged in");
                            }
                            else
                            {
                                Net.sendMsg(_socket.GetStream(), "Failed to log in");
                            }
                        }
                    }
                    else if (message[0].Equals("Signin"))
                    {
                        if (!this.logged)
                        {
                            this.login = message[1];
                            string password = message[2];
                            if (this.server.addNewUser(this.login, password))
                            {
                                this.logged = true;
                                Net.sendMsg(_socket.GetStream(), "Logged in");
                            }
                            else
                            {
                                Net.sendMsg(_socket.GetStream(), "Username already exist");
                            }
                        }
                    }
                    else if (message[0].Equals("EnterDiscussion"))
                    {
                        //Adding a new _socket into a disc from dicoTopics
                        this.server.addSocketInDisc(message[1], _socket);
                    }
                    else if (message[0].Equals("ShowTopics"))
                    {
                        // Server should return the list of topics using _socket
                        Net.sendMsg(_socket.GetStream(), this.server.shareTopicsUsingSocket());
                    }
                    else if (message[0].Equals("ShowUsers"))
                    {
                        // Server should return the list of users using _socket
                        Net.sendMsg(_socket.GetStream(), this.server.shareUsersUsingSocket());
                    }
                    else if (message[0].Equals("newPriv"))
                    {
                        this.login = message[1];
                        this.server.createPrivDisc(this.login,this._socket , message[2]);
                    }
                    else if (message[0].Equals("joinPriv"))
                    {
                        this.login = message[2];
                        this.server.joinPrivDisc(message[1], this.login, this._socket);
                    }
                    // At the client creation, a socket wait a private discussion request in this socket
                    else if (message[0].Equals("addNewPrivSocket"))
                    {
                        this.login = message[1];
                        this.server.addUserOnline(this.Socket, this.login);
                    }
                    else if (message[0].Equals("Topic"))
                    {
                        // Adding a new topic (pair element) into dicoTopics
                        bool valid = this.server.createTopic(message[1]);
                        if (valid)
                        {
                            Net.sendMsg(_socket.GetStream(), "success");
                        }
                        else
                        {
                            Net.sendMsg(_socket.GetStream(), "failed");
                        }
                    }
                    else if (message[0].Equals("Leave"))
                    {
                        // Remove the _socket of the disc
                        if (message[2].Equals("topic"))
                        {
                            this.server.leaveTopic(message[1], this._socket);
                        }
                        else
                        {
                            this.server.leavePriv(message[1], this.login , this._socket);
                        }
                        break;
                    }
                    //The users goes offline
                    else if (message[0].Equals("Disconnect"))
                    {
                        this.server.disconnect(this.login);
                        break;
                    }
                    else if (message[0].Equals("ChatTopic"))
                    {
                        foreach (TcpClient socket in this.server.getListOfUsersOfTopic(message[1]))
                        {
                            Net.sendMsg(socket.GetStream(), message[2] + "#" + message[3] + "#" + message[4] + "#" + message[5]);
                        }
                    }
                    else if (message[0].Equals("ChatPriv"))
                    {
                        foreach (TcpClient socket in this.server.getListOfUsersOfPriv(message[1]))
                        {
                            Net.sendMsg(socket.GetStream(), message[2] + "#" + message[3] + "#" + message[4] + "#" + message[5]);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("InvalidOperationException SocketController");
                }
                finally
                {
                    Console.WriteLine(this.server.displayUsers());
                    Console.WriteLine(this.server.displayPriv());
                    Console.WriteLine(this.server.displayTopics());      
                }

            }
        }
        public TcpClient Socket
        {
            get
            {
                return this._socket;
            }
        }
    }
}
