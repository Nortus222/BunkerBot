﻿using System;
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
        public List<BunkerUser> Get()
        {
            return BunkerUsers;
        }

        public static void ClearList()
        {
            BunkerUsers.Clear();
            
        }
        private static TelegramBotClient client;

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
            await client.SendTextMessageAsync(e.CallbackQuery.From.Id, $"{e.CallbackQuery.From.FirstName} pressed {e.CallbackQuery.Data}");
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {

            CommandService commands = new CommandService();

            var message = messageEventArgs.Message;
            var newUser = new BunkerUser(message.From.FirstName,message.Chat.Id);
            bool exist = false;
            foreach(var user in BunkerUsers)
            {
                if(message.Chat.Id == user.ChatID)
                {
                    exist = true;
                }
            }
            if(!exist) BunkerUsers.Add(newUser);
            
            foreach(var user in BunkerUsers)
            {
                await client.SendTextMessageAsync(message.Chat.Id,(user.NickName));
            }  

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