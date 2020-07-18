using System;
namespace BunkerBot2
{
    public class User
    {

        private long chatID;

        private string nickName;

        private bool isHost;

        public User(string NickName, long ChatID, bool isHost = false)
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
        }

        public bool Equals(User other) => other.ChatID == this.ChatID;
    }
}
