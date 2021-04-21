using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchPlays.model;

namespace TwitchPlays.control {
    class GameController {

        private Game game;

        public GameController(Game game) {
            this.game = game;
        }

        public void sendKey(String key) {
            //TODO
            Console.WriteLine("calling sendKey(" + key + ")");
        }

        public void sendClick(int x, int y, Boolean hold) {
            Console.WriteLine("calling sendClick(" + x + "," + y + "," + hold + ")");
        }

        public void runCommandOnGame(String command) {
            if(null != game) {
                GameCommand cmd = game.getGammeCommand(command);
                if (null != cmd) {
                    switch (cmd.getType()) {
                        case "key":
                            sendKey(cmd.getAction().ToString());
                            break;
                        case "click":
                            string[] positions = cmd.getAction().ToString().Split(',');
                            sendClick(int.Parse(positions[0]), int.Parse(positions[1]), positions[1].Equals("1"));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
}
