using Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectChatApp.ClientSide
{
    public partial class PrivateDisc : Form
    {
        public PrivateDisc()
        {
            InitializeComponent();
            Net.sendMsg(Program.client.getTopicByKey("Person").GetStream(), "ShowUsers");
            string[] users = Net.rcvMsg(Program.client.getTopicByKey("Person").GetStream()).Split('#');
            for (int i = 0; i < users.Length; i++)
            {
                // Create as many buttons as users
                if (!users[i].Equals(Program.client.Login))
                {
                    createUserButton(users[i], i * 50 + 70);
                } 
            }
        }
        public void createUserButton(String txt, int y)
        {
            Button btnUser = new Button();
            btnUser.Text = txt;
            btnUser.Location = new System.Drawing.Point(260, y);
            btnUser.Size = new System.Drawing.Size(264, 53);
            btnUser.Click += new EventHandler(btnUser_Click);
            this.Controls.Add(btnUser);
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            String userCalled = (sender as Button).Text;
            //if (Program.client.validPrivDisc(user))

            this.Hide();
            // Add socket in Client list of disc joined
            Program.client.addPrivSocket(userCalled, new TcpClient("127.0.0.1", 8976));
            // Add sockets in Server's sockets list per priv disc
            Net.sendMsg(Program.client.getPrivByKey(userCalled).GetStream(), "newPriv#" + Program.client.Login +"#" + userCalled);
            Chat c = new Chat(userCalled, false);
            c.Show();

            
        }
    }
}
