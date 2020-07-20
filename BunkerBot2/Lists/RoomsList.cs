using System;
using System.Collections.Generic;
using Bot1;
using Telegram.Bot;

namespace BunkerBot2.Lists
{
    public class RoomsList
    {

        private List<Room> rooms = new List<Room>();
        public List<Room> Rooms => rooms;

        public RoomsList()
        {

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
                rooms.Add(new Room(user));
                Program.SendMessage(user, "The room has been created.");
                return true;
            }
            return false;
        }

        public void DeleteRoom(BunkerUser user)
        {
            var tmp = new List<Room>();
            bool catched = false;
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Host == user) 
                {
                    rooms[i].ClearRoom();
                    user.IsHost =false;
                    catched = true;
                }
                else
                {
                    tmp.Add(rooms[i]);
                }    
            }
            if(catched)
            {
                rooms = tmp;
                Program.SendMessage(user, "Room has been deleted.");
            }
            else
            {
                Program.SendMessage(user, "You are not a host");
            }
        }

        public void ClearRoomList()
        {
            rooms.Clear();
        }
    }
}
