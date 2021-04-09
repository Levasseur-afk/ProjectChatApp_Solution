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
    public partial class CreateTopic : Form
    {
        public CreateTopic()
        {
            InitializeComponent();
            this.Text = Program.client.Login + " : Create Topic";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // The # is used to split message, it's not allowed to use it as name of a topic
            if (!textBox1.Text.Contains('#'))
            {
                string topic = textBox1.Text;
                Net.sendMsg(Program.client.getTopicByKey("Person").GetStream(), "Topic#" + topic);
                String allowed = Net.rcvMsg(Program.client.getTopicByKey("Person").GetStream());
                if (allowed.Equals("success"))
                {
                    Program.client.addSocket(topic, new TcpClient("127.0.0.1", 8976));
                    // Add socket in Server's sockets list per disc
                    Net.sendMsg(Program.client.getTopicByKey(topic).GetStream(), "EnterDiscussion#" + topic);

                    this.Hide();
                    Chat c = new Chat(topic, true);
                    c.Show();
                }
                else
                {
                    //Vide l'input
                    textBox1.Text = "";
                }
            }  
        }
    }
}
