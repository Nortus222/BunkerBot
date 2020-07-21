using System;
using System.Collections.Generic;

namespace BunkerBot2
{
    public class BunkerUser
    {
        public BunkerUser(string NickName, long ChatID, bool isHost = false, bool isPlayer = false)
        {
            this.ChatID = ChatID;
            this.NickName = NickName;
            this.IsHost = isHost;
            this.IsPlayer = isPlayer;
        }

        public long ChatID { get; }

        public string NickName { get; }

        public bool IsHost { get; set; }

        public bool IsPlayer { get; set; }

        public bool Equals(BunkerUser other) => other.ChatID == this.ChatID;

        public bool EqualID(long other) => other == this.ChatID;

        public List<string> Card = new List<string>();
    }
}
