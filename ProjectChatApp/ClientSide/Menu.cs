using Communication;
using ProjectChatApp.ClientSide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectChatApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.Text = Program.client.Login + " : Menu";
        }

        private void joinTopic_Click(object sender, EventArgs e)
        {
            JoinTopic jt = new JoinTopic();
            jt.Show();
        }

        private void newTopic_Click(object sender, EventArgs e)
        {
            CreateTopic ct = new CreateTopic();
            ct.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Send instruction to remove each sockets from the server
            Program.client.leaveAll();
            //Stop all receiving threads from Chat(s)
            Program.client.closeThreadsFromChats();
            //Send instruction to disconnect
            Net.sendMsg(Program.client.getTopicByKey("Person").GetStream(), "Disconnect");
            Program.client.getTopicByKey("Person").Close();
            // Exit the program to close all
            Application.Exit();
        }

        private void privateConv_Click(object sender, EventArgs e)
        {
            PrivateDisc privD = new PrivateDisc();
            privD.Show();
        }
    }
}
