using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlays.model {
    class GameCommand {
        private String type;
        private String command;
        private String action;

        public GameCommand() {

        }

        public GameCommand(String type, String command, String action) {
            this.setType(type);
            this.setCommand(command);
            this.setAction(action);
        }

        public String getType() {
            return type;
        }

        public void setType(String value) {
            type = value;
        }

        public String getCommand() {
            return command;
        }

        public void setCommand(String value) {
            command = value;
        }

        public String getAction() {
            return action;
        }

        public void setAction(String value) {
            action = value;
        }
    }
}
