using System.Collections.Generic;
using System;
using Bot1;

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

        public List<BunkerUser> Players => players;
        
        public void RemovePlayer(BunkerUser user)
        {
            players.Remove(user);
        }

        public bool AddToRoom(BunkerUser user)
        {
            foreach(var room in Program.GetRooms.Rooms)
            {
                if (room.Players.Contains(user))
                {
                    Console.WriteLine("Fuck");
                    return false;
                }
            }
            this.players.Add(user);
            return true;
            
        }

        public void DisplayRoom()
        {
            foreach(BunkerUser user in players)
            {
                Console.WriteLine(user.NickName);
            }
        }

        public void ClearRoom()
        {
            players.Clear();
        }

    }
}