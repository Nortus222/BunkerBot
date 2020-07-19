using System;
namespace BunkerBot2
{
    public class BunkerUser
    {

        private long chatID;

        private string nickName;

        private bool isHost;

        public BunkerUser(string NickName, long ChatID, bool isHost = false)
        {
            this.chatID = ChatID;
            this.nickName = NickName;
            this.isHost = isHost;
        }

        public long ChatID
        {
            get { return this.chatID; }
        }

        public string NickName
        {
            get { return this.nickName; }
        }

        public bool IsHost
        {
            get { return this.isHost; }

            set {this.isHost = value; }
        }

        public bool Equals(BunkerUser other) => other.ChatID == this.ChatID;

        public bool EqualID(long other) => other == this.ChatID;
    }
}
