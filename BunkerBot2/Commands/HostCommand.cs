using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using BunkerBot2.Abstractions;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace BunkerBot2.Commands
{
    public class HostCommand: TelegramCommand
    {
        public HostCommand()
        {
        }

        public override string Name { get; } = "/host";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
            {
                return false;
            }

            return message.Text.Contains(Name); 
        }


        //TODO: is it better to take User instead of Message?
        public override async Task Execute(Message message, ITelegramBotClient client) 
        {
            throw new NotImplementedException();
        }
    }
}
