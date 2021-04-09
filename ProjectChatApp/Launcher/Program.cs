using ProjectChatApp.ClientSide;
using ProjectChatApp.Launcher;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectChatApp
{
    static class Program
    {
        public static Client client;
        public static List<Rgb> colors;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            colors = new List<Rgb>();
            addColors();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                client = new Client();
                Application.Run(new Welcome());
            }
            catch (System.Net.Sockets.SocketException)
            {
                // The server hasn't started yet, it's not possible to start a client
            }
        }
        public static void addColors()
        {
            colors.Add(new Rgb(0,255,255));
            colors.Add(new Rgb(0, 0, 0));
            colors.Add(new Rgb(0, 0, 255));
            colors.Add(new Rgb(138, 43, 226));
            colors.Add(new Rgb(165, 42, 42));
            colors.Add(new Rgb(127, 255, 0));
            colors.Add(new Rgb(0, 100, 0));
            colors.Add(new Rgb(255, 20, 147));
            colors.Add(new Rgb(255, 69, 0));
            colors.Add(new Rgb(0, 0, 128));
            colors.Add(new Rgb(32, 178, 170));
        }
        // Return a random color
        public static Rgb rdmColor()
        {
            Random rdm = new Random();
            return colors[rdm.Next(1, colors.Count)];
        }
    }
}
