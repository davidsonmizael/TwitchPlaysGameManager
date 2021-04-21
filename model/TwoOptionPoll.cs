using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlays.model {

    class TwoOptionPoll {
        private GameCommand firstCmd;
        private int firstCount;
        private GameCommand secondCmd;
        private int secondCount;
        private List<string> usersWhoVoted;

        public TwoOptionPoll(GameCommand first, GameCommand second) {
            this.setFirstCmd(first);
            this.setSecondCmd(second);
            this.setFirstCount(0);
            this.setSecondCount(0);
            usersWhoVoted = new List<string>();
        }

        public GameCommand getFirstCmd() {
            return firstCmd;
        }

        public void setFirstCmd(GameCommand value) {
            firstCmd = value;
        }

        public int getFirstCount() {
            return firstCount;
        }

        public void setFirstCount(int value) {
            firstCount = value;
        }

        public GameCommand getSecondCmd() {
            return secondCmd;
        }
        public void setSecondCmd(GameCommand value) {
            secondCmd = value;
        }
        public int getSecondCount() {
            return secondCount;
        }
        public void setSecondCount(int value) {
            secondCount = value;
        }

        public void setUsersWhoVoted(List<string> value) {
            usersWhoVoted = value;
        }

        public List<string> getUsersWhoVoted() {
            return usersWhoVoted;
        }

        public void addToUserWhoVoted(string user) {
            usersWhoVoted.Add(user);
        }

        public Boolean hasUserVoted(string user) {
            return usersWhoVoted.Contains(user);
        }

    }
}
