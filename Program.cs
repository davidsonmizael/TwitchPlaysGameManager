using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchPlays.control;
using TwitchPlays.model;

namespace TwitchPlays {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            string server = Properties.Settings.Default.server;
            int port = Properties.Settings.Default.port;
            string username = Properties.Settings.Default.username;
            string channel = Properties.Settings.Default.channel;
            string password = Properties.Settings.Default.password;

            IRCController irc = new IRCController(server, port, username, channel, password);
            Thread t = new Thread(new ThreadStart(irc.run));
            t.Start();

            GameCommand cmd1 = new GameCommand("click", "!left", "1,2,1");
            GameCommand cmd2 = new GameCommand("click", "!right", "1,1,1");

            TwoOptionPoll poll = new TwoOptionPoll(cmd1, cmd2);

            irc.setCurrentPoll(poll);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TwitchPlays());
        }
    }
}
