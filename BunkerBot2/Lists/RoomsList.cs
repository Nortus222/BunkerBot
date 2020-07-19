using System;
using System.Collections.Generic;
using Bot1;
using Telegram.Bot;

namespace BunkerBot2.Lists
{
    public class RoomsList
    {

        public List<Room> Rooms { get; }

        public RoomsList(List<Room> rooms)
        {
            Rooms = rooms;
            
        }

        public bool CreateRoom(BunkerUser user)
        {
            bool hasRoom = false;
            foreach (var room in Rooms)
            {
                if (room.Host == user)
                {
                    Program.SendMessage(user, "You already have a room. Use it or delete it.");
                    hasRoom = true;
                }
            }
            if (!hasRoom)
            {
                Rooms.Add(new Room(user));
                Program.SendMessage(user, "The room has been created.");
                return true;
            }
            return false;
        }

        public void DeleteRoom(BunkerUser user)
        {
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].Host == user) Rooms.Remove(Rooms[i]);
                return;
            }
            Program.SendMessage(user, "You are not a host");
        }
    }
}
