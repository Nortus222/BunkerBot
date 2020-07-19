using System;
using static System.Console;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading.Tasks;
using System.Threading;
using BunkerBot2.Commands;
using BunkerBot2.Service;
using BunkerBot2.Abstractions;
using BunkerBot2;


namespace Bot1
{
    class Program
    {
        private static List<BunkerUser> BunkerUsers = new List<BunkerUser>();
        private static List<Room> rooms = new List<Room>();
        public static List<BunkerUser> Get()
        {
            return BunkerUsers;
        }

        public static List<Room> GetRooms()
        {
            return rooms;
        }

        public static void ClearList()
        {
            BunkerUsers.Clear();
        }

        public static void AddUser(BunkerUser user)
        {
            BunkerUsers.Add(user);
        }

        public static BunkerUser GetUserById(long id)
        {
            foreach(BunkerUser user in BunkerUsers)
            {
                if(id == user.ChatID)
                {
                    return user;
                }
            }

            return null;
        }

        public static void  RemoveUser(BunkerUser user)
        {
            BunkerUsers.Remove(user);
        }

        public static bool CheckExistance(BunkerUser user)
        {
            foreach(var us in BunkerUsers)
            {
                if(us.ChatID == user.ChatID)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CreateRoom(BunkerUser user)
        {
            bool hasRoom=false;
            foreach(var room in rooms)
            {
                if(room.Host == user)
                {
                    client.SendTextMessageAsync(user.ChatID, "You already have a room. Use it or delete it.");
                    hasRoom=true;
                }
            }
            if(!hasRoom)
            {   
                rooms.Add(new Room(user));
                client.SendTextMessageAsync(user.ChatID,"The room has been created.");
                return true;
            }
            return false;
        }
        public static async void DeleteRoom(BunkerUser user)
        {
            for(int i =0;i<rooms.Count;i++)
            {
                if(rooms[i].Host==user) rooms.Remove(rooms[i]);
                return;
            }
            await client.SendTextMessageAsync(user.ChatID,"You are not a host");
        }

        private static TelegramBotClient client;

        private static CommandService commands = new CommandService();

        static void Main(string[] args)
        {
            client = new TelegramBotClient("1111775546:AAEqesvfDbF-UDS48I1OtwAxNprAFvkJ_NI");
            client.OnMessage += BotOnMessageReceived;
            client.OnMessageEdited += BotOnMessageReceived;
            client.OnCallbackQuery += BotOnCallbackQueryReceived;
            client.StartReceiving();
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
        {

            var message = e.CallbackQuery.Data;

            foreach(Room room in rooms)
            {
                if(room.Host.NickName == message)
                {
                    room.AddToRoom(GetUserById(e.CallbackQuery.From.Id));
                    room.DisplayRoom();

                }
            }

            BunkerUser curUser;

            foreach(BunkerUser currentUser in BunkerUsers)
            {

                if (currentUser.EqualID(e.CallbackQuery.From.Id))
                {
                    curUser = currentUser;
                    foreach (TelegramCommand command in commands.Get())
                    {
                        if (command.Contains(message))
                        {

                            await command.Execute(curUser, client);
                            break;
                        }

                    }
                    break;
                }
            }
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {

            var message = messageEventArgs.Message;
            var newUser = new BunkerUser(message.From.FirstName,message.Chat.Id);
            
            if (message?.Type == MessageType.Text)
                await client.SendTextMessageAsync(message.Chat.Id, "/start - start");
            {
                
                        
                foreach(TelegramCommand command in commands.Get())
                {       
                     if (command.Contains(message.Text))
                     {
                                
                         await command.Execute(newUser, client);
                         
                     }
                       
                }

            }

        }
    }
}