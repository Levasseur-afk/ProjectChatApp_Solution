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
    public partial class JoinTopic : Form
    {
        public JoinTopic()
        {
            InitializeComponent();
            this.Text = Program.client.Login + " : Join Topic";
            Net.sendMsg(Program.client.getTopicByKey("Person").GetStream(), "ShowTopics");
            string[] topics = Net.rcvMsg(Program.client.getTopicByKey("Person").GetStream()).Split('#');
            for (int i = 0; i < topics.Length; i++)
            {
                // Create as many buttons as topics
                createTopicButton(topics[i], i * 70 + 90);
            }
        }
        public void createTopicButton(String txt, int y)
        {
            Button btnTopic = new Button();
            btnTopic.Text = txt;
            btnTopic.Location = new System.Drawing.Point(260, y);
            btnTopic.Size = new System.Drawing.Size(264, 53);
            btnTopic.Click += new EventHandler(btnTopic_Click);
            this.Controls.Add(btnTopic);
        }
        private void btnTopic_Click(object sender, EventArgs e)
        {
     
            String topic = (sender as Button).Text;
            if (Program.client.validJoin(topic))
            {
                this.Hide();
                // Add socket in Client list of discussion joined
                Program.client.addSocket(topic, new TcpClient("127.0.0.1", 8976));
                // Add socket in Server's sockets list per disc
                Net.sendMsg(Program.client.getTopicByKey(topic).GetStream(), "EnterDiscussion#" + topic);
                Chat c = new Chat(topic, true);  
                c.Show();
            }      
        }
    }
}
