﻿using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using BunkerBot2.Abstractions;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace BunkerBot2.Commands
{
    public class JoinCommand: TelegramCommand
    {
        public JoinCommand()
        {
        }

        public override string Name { get; } = "/join";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
            {
                return false;
            }

            return message.Text.Contains(Name);
        }

        public override Task Execute(Message message, ITelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
