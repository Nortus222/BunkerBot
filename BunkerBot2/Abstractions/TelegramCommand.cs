using System;
using Telegram.Bot;
using Telegram.Bot.Args;


namespace BunkerBot2.Abstractions
{
    public abstract class TelegramCommand
    {
        public abstract string Name { get; }

        public abstract Task Execute
    }
}
