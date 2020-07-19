using System.Collections.Generic;

namespace BunkerBot2
{
    public class Room
    {
        public Room(BunkerUser host)
        {
            this.host = host;
            players.Add(host);
        }
        private BunkerUser host;
        private List<BunkerUser> players;

    }
}