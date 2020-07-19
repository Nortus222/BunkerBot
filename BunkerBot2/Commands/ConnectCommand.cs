using System;
using Telegram.Bot;
using System.Collections.Generic;
using Telegram.Bot.Args;
using BunkerBot2.Abstractions;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Bot1;

namespace BunkerBot2.Commands
{
    public class ConnectCommand: TelegramCommand
    {
        public ConnectCommand()
        {
        }

        public override string Name { get; } = "/connect";

        public override Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
