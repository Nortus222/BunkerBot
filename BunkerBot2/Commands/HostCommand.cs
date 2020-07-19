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

        //TODO: is it better to take User instead of Message?
        public override async Task Execute(User user, ITelegramBotClient client) 
        {
            
        }
    }
}
