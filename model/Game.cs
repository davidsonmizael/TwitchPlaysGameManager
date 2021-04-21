using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlays.model {
    class Game {
        public String name;
        public String processName;
        public DateTime startTime;
        public Dictionary<String, GameCommand> gameCommands;

        public Game(String name, String processName) {
            this.name = name;
            this.processName = processName;
            this.gameCommands = new Dictionary<String, GameCommand>();
        }

        public String getName() {
            return this.name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getProcessName() {
            return this.processName;
        }

        public void setProcessName(String processName) {
            this.processName = processName;
        } 

        public DateTime getStartTime() {
            return this.startTime;
        }

        public void setStartTime() {
            this.startTime = DateTime.Now;
        }

        public GameCommand getGammeCommand(String name) {
            return this.gameCommands[name];
        }

        public void addGameCommand(String name, GameCommand gameCommand) {
            this.gameCommands.Add(name, gameCommand);
        }

        public void removeGameCommand(String name) {
            this.gameCommands.Remove(name);
        }

        public void resetGameCommands() {
            this.gameCommands = new Dictionary<String, GameCommand>();
        }
    }
}
