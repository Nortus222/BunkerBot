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
        public static List<BunkerUser> Get()
        {
            return BunkerUsers;
        }

        public static void ClearList()
        {
            BunkerUsers.Clear();
        }

        public static void AddUser(BunkerUser user)
        {
            BunkerUsers.Add(user);
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

            Console.WriteLine(message);
            BunkerUser curUser;

            foreach(BunkerUser currentUser in BunkerUsers)
            {
                Console.WriteLine("111");
                Console.WriteLine(currentUser.ChatID);
                Console.WriteLine(e.CallbackQuery.From.Id);
                if (currentUser.EqualID(e.CallbackQuery.From.Id))
                {
                    curUser = currentUser;
                    foreach (TelegramCommand command in commands.Get())
                    {
                        Console.WriteLine("command");
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
                     if (command.Contains(message))
                     {
                                
                         await command.Execute(newUser, client);
                         
                     }
                       
                }

            }

        }
    }
}