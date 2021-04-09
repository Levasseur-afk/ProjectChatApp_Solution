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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            //Console1.Text += "\r\n" + "Connected to server";
            Console.WriteLine("Welcome");
        }

        // Function to handle login click
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            Net.sendMsg(Program.client.getTopicByKey("Person").GetStream(), "Login#" + inputLogin.Text + "#" + inputPassword.Text);
            String answer = Net.rcvMsg(Program.client.getTopicByKey("Person").GetStream());
            if (answer.Equals("Logged in"))
            {
                Program.client.Login = inputLogin.Text;
                Program.client.startPrivListener();
                this.Hide();
                Menu f2 = new Menu();
                f2.Show();
            }
            else
            {
                Console1.Text += "\r\n" + answer;
            }
        }

        // Function to handle Sign in click
        private void button1_Click(object sender, EventArgs e)
        {
            // The # is used to split message, it's not allowed to use it in credentials
            if(!inputLogin.Text.Contains('#') && !inputPassword.Text.Contains('#'))
            {
                Net.sendMsg(Program.client.getTopicByKey("Person").GetStream(), "Signin#" + inputLogin.Text + "#" + inputPassword.Text);
                String answer = Net.rcvMsg(Program.client.getTopicByKey("Person").GetStream());
                if (answer.Equals("Logged in"))
                {
                    Program.client.Login = inputLogin.Text;
                    Program.client.startPrivListener();
                    this.Hide();
                    Menu f2 = new Menu();
                    f2.Show();
                }
                else
                {
                    Console1.Text += "\r\n" + answer;
                }
            }    
        }
    }
}
