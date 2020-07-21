using System.Collections.Generic;
using System;
using Bot1;
using BunkerBot2.Service;
using BunkerBot2.Lists;

namespace BunkerBot2
{
    public class Room
    {
        public Room(BunkerUser user)
        {
            this.host = user;
            players.Add(user);
            user.IsPlayer = true;
        }
        private BunkerUser host;

        public BunkerUser Host{get {return host;}}

        public  List<BunkerUser> players = new List<BunkerUser>();

        public List<BunkerUser> Players => players;

        public bool ContainsUser(BunkerUser user)
        {
            foreach(BunkerUser player in players)
            {
                if (player.Equals(user))
                {
                    return true;
                }
            }
            return false;
        }
        
        public void RemovePlayer(BunkerUser user)
        {
            if (user.IsHost)
            {
                user.IsHost = false;
                user.IsPlayer = false;
                players.Remove(user);
                Notify($"{user.NickName} left");
                if(players.Count > 0)
                {
                    players[0].IsHost = true;
                    host = players[0];
                    Program.SendMessage(host, "You are a host now");

                }
                else
                {
                    Program.rooms.DeleteRoom(user);
                }
            }
            else
            {
                players.Remove(user);
                user.IsPlayer = false;
                Notify($"{user.NickName} left");
            }
            
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
            user.IsPlayer = true;
            Notify($"{user.NickName} joined");
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
            host = null;
        }

        public void Notify(string message)
        {
            foreach(BunkerUser player in players)
            {
                Program.SendMessage(player, message);
            }
        }

        public BunkerUser GetPlayerByName(string name)
        {
            foreach(BunkerUser player in players)
            {
                if(player.NickName == name)
                {
                    return player;
                }
            }
            return null;
        }

    }
}