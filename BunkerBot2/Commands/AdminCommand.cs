using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using BunkerBot2.Abstractions;
using Telegram.Bot.Types;
using System.Threading.Tasks;

namespace BunkerBot2.Commands
{
    public class AdminCommand: TelegramCommand
    {
        public AdminCommand()
        {
        }

        public override string Name { get; } = "Help";

        public override bool Contains(Message message)
        {
            throw new NotImplementedException();
        }


        //TODO: is it better to take User instead of Message?
        public override async Task Execute(Message message, ITelegramBotClient client) 
        {
            throw new NotImplementedException();
        }
    }
}
