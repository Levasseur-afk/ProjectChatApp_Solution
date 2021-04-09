using Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectChatApp.ClientSide
{
    public partial class Chat : Form
    {
        private String name;
        private Thread chat;
        private bool isTopic;
        public Chat(String name, bool isTopic)
        {
            Program.client.addChat(this);
            this.isTopic = isTopic;
            this.name = name;
            InitializeComponent();
            this.Text = Program.client.Login + " talking at " + this.name;
            this.chat = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        String[] m;
                        if (this.isTopic)
                        {
                            m = Net.rcvMsg(Program.client.getTopicByKey(this.name).GetStream()).Split('#');
                        }
                        else
                        {
                            m = Net.rcvMsg(Program.client.getPrivByKey(this.name).GetStream()).Split('#');
                        }
                        //chatBox.Invoke((MethodInvoker)delegate { chatBox.Text += "\r\n" + m; });
                        Color color = Color.FromArgb(Convert.ToInt32(m[0]), Convert.ToInt32(m[1]), Convert.ToInt32(m[2]));
                        chatBox.Invoke((MethodInvoker)delegate { AppendText(chatBox, "\r\n" + m[3], color); });
                    }
                    catch (System.InvalidOperationException)
                    {
                        // a voir
                    }
                }
            });
            chat.Start();
        }
        private void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (this.isTopic)
            {
                Net.sendMsg(Program.client.getTopicByKey(this.name).GetStream(), "ChatTopic#" + this.name + "#" + Program.client.getColor().R + "#" + Program.client.getColor().G + "#" + Program.client.getColor().B + "#" + Program.client.Login + " : " + input.Text);
            }
            else
            {
                Net.sendMsg(Program.client.getPrivByKey(this.name).GetStream(), "ChatPriv#" + this.name + "/" + Program.client.Login + "#" + Program.client.getColor().R + "#" + Program.client.getColor().G + "#" + Program.client.getColor().B + "#" + Program.client.Login + " : " + input.Text);
            }
            input.Text = String.Empty;   
        }
        private void leaveChat_Click(object sender, EventArgs e)
        {
            this.Close();
            // Stop the thread running
            try
            {
                this.chat.Abort();
            }
            catch (ThreadAbortException)
            {
                // Nothing to do
            }
            finally
            {
                if (this.isTopic)
                {
                    //Send instruction to remove the topic socket from the server
                    Net.sendMsg(Program.client.getTopicByKey(this.name).GetStream(), "Leave#" + name + "#topic");
                    Program.client.removeTopicByKey(this.name);
                }
                else
                {
                    //Send instruction to remove the private disc socket from the server
                    Net.sendMsg(Program.client.getPrivByKey(this.name).GetStream(), "Leave#" + name + "#priv");
                    Program.client.removePrivByKey(this.name);
                }
                
                // Remove the socket from the list of socket of the client
                
                Program.client.removeChat(this);
            }
        }
        public Thread getChat()
        {
            return this.chat;
        }
    }
}
