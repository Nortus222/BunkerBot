using System;
using static System.Console;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Bot1
{
    class Program
    {
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient("1111775546:AAEqesvfDbF-UDS48I1OtwAxNprAFvkJ_NI");
            client.OnMessage += BotOnMessageReceived;
            client.OnMessageEdited += BotOnMessageReceived;
            //client.SendTextMessageAsync()
            client.StartReceiving();
            Console.ReadLine();
            client.StopReceiving(); 
        }
        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;         
            if (message?.Type == MessageType.Text)
            await client.SendTextMessageAsync(message.Chat.Id, "/start - start");
            //string start = "/start";
            {
                // switch (message.Text)
                // {
                //     case start:
                //     await client.SendTextMessageAsync(message.Chat.Id, "Welcome");
                // }
                if(message.Text == "/start")
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Welcome");
                }
            }
        } 
                    
    }
}
