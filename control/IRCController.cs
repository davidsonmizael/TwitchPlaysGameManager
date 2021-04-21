using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using TwitchPlays.model;

namespace TwitchPlays.control {

    class IRCController {

        private string server;
        private int port;
        private string username;
        private string channel;
        private string password;
        private TwoOptionPoll currentPoll;
        private Boolean isChaosActivated;

        public IRCController(string server, int port, string username, string channel, string password) {
            this.server = server;
            this.port = port;
            this.username = username;
            this.channel = channel;
            this.password = password;
            this.isChaosActivated = false;
        }

        public void run() {
            using (var client = new TcpClient()) {
                Console.WriteLine($"Connecting to {this.server}");
                client.Connect(this.server, this.port);
                Console.WriteLine($"Connected: {client.Connected}");

                using (var stream = client.GetStream()) {
                    using (var writer = new StreamWriter(stream)) {
                        using (var reader = new StreamReader(stream)) {
                            writer.WriteLine($"PASS {this.password}");
                            writer.WriteLine($"NICK {this.username}");

                            writer.Flush();

                            while (client.Connected) {
                                var data = reader.ReadLine();

                                if (!string.IsNullOrEmpty(data)) {
                                    Console.WriteLine(data);
                                    var d = data.Split(' ');
                                    if (d.First().ToUpper().Equals("PING")) {
                                        Console.WriteLine("PONG :tmi.twitch.tv");
                                        writer.WriteLine("PONG :tmi.twitch.tv");
                                        writer.Flush();
                                        continue;
                                    }else if (d.Length > 1) {
                                        if (d[1].Equals("376")) {
                                            writer.WriteLine($"JOIN #{this.channel}");
                                            writer.Flush();
                                            continue;
                                        }
                                        if (d[1].Equals("PRIVMSG")) {
                                            string message = data.Split(':')[2];
                                            string user = d[0].Split('!')[1].Split('@')[0];
                                            if (message.StartsWith("!")) {
                                                if (isChaosActivated) {

                                                }else if (null != currentPoll) {
                                                    if (currentPoll.getFirstCmd().getCommand().Equals(message.ToLower())) {
                                                        if (!currentPoll.hasUserVoted(user)) {
                                                            currentPoll.setFirstCount(currentPoll.getFirstCount() + 1);
                                                            currentPoll.addToUserWhoVoted(user);
                                                            Console.WriteLine("User voted for " + currentPoll.getFirstCmd().getAction());
                                                        }
                                                    }
                                                    else if (currentPoll.getSecondCmd().getCommand().Equals(message.ToLower())) {
                                                        if (!currentPoll.hasUserVoted(user)) {
                                                            currentPoll.setSecondCount(currentPoll.getSecondCount() + 1);
                                                            currentPoll.addToUserWhoVoted(user);
                                                            Console.WriteLine("User voted for " + currentPoll.getSecondCmd().getAction());
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public void setCurrentPoll(TwoOptionPoll currentPoll) {
            this.currentPoll = currentPoll;
        }

        public TwoOptionPoll getCurrentPoll() {
            return this.currentPoll;
        }

        public void endPoll() {
            this.currentPoll = null;
        }

        public void activateChaos() {
            this.isChaosActivated = true;
        }

        public void deactivateChaos() {
            this.isChaosActivated = false;
        }

    }
}
