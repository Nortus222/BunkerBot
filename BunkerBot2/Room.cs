using System.Collections.Generic;

namespace BunkerBot2
{
    public class Room
    {
        public Room(BunkerUser user)
        {
            this.host = user;
            players.Add(user);
        }
        private BunkerUser host;
        public BunkerUser Host{get {return host;}}
        private  List<BunkerUser> players = new List<BunkerUser>();

    }
}