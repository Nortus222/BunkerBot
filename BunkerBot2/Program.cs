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
using BunkerBot2.Lists;



namespace Bot1
{
    class Program
    {
       
        public static BunkerUsersList bunkerUsers = new BunkerUsersList();

        public static RoomsList rooms = new RoomsList();

        public static RoomsList GetRooms => rooms;

        public static BunkerUsersList GetBunkerUsers => bunkerUsers;

        private static TelegramBotClient client;

        private static CommandService commands = new CommandService();

        public static CommandService GetCommands => commands;

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

            foreach(Room room in rooms.Rooms)
            {
                if(room.Host.NickName == message)
                {
                    room.AddToRoom(GetBunkerUsers.GetUserById(e.CallbackQuery.From.Id));
                    room.DisplayRoom();

                }
            }

            BunkerUser curUser;

            foreach (BunkerUser currentUser in GetBunkerUsers.Users)
            {

                if (currentUser.EqualID(e.CallbackQuery.From.Id))
                {
                    curUser = currentUser;
                    foreach (TelegramCommand command in commands.GetAll())
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

            if (bunkerUsers.CheckExistance(newUser))
            {
                newUser = bunkerUsers.GetUserById(message.Chat.Id);
            }
            else
            {
                if (message.Text == "/start")
                {
                    await commands.GetStartCommand().Execute(newUser, client);
                    return;
                }
                else
                {
                    await client.SendTextMessageAsync(newUser.ChatID, "You are not in system.\nUse /start to jump into the game.");
                    return;
                }
            }
            
            if (message?.Type == MessageType.Text)
            {
                foreach(TelegramCommand command in commands.GetAll())
                {       
                     if (command.Contains(message.Text))
                     {
                                
                         await command.Execute(newUser, client);
                         
                     }
                       
                }

            }

        }

        public static async void SendMessage(BunkerUser user, string message)
        {
            await client.SendTextMessageAsync(user.ChatID, message);
        }
    }
}