using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using BunkerBot2.Abstractions;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Bot1;

namespace BunkerBot2.Commands
{
    public class HostCommand: TelegramCommand
    {
        public HostCommand()
        {
        }

        public override string Name { get; } = "/host";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client) 
        {
            
            user.IsHost = true;

            await client.SendTextMessageAsync(user.ChatID, "You are now a host");
            Program.CreateRoom(user);
            
        }
    }
}
