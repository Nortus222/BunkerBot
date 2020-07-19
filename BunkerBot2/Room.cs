using System.Collections.Generic;
using System;

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

        public bool AddToRoom(BunkerUser user)
        {
            if (players.Contains(user))
            {
                return false;
            }
            else
            {
                this.players.Add(user);
            }

            return true;
            
        }

        public void DisplayRoom()
        {
            foreach(BunkerUser user in players)
            {
                Console.WriteLine(user.NickName);
            }
        }

    }
}