using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Threading.Tasks;
using Telegram.Bot.Types;



namespace BunkerBot2.Abstractions
{
    public abstract class TelegramCommand
    {
        public abstract string Name { get; }

        public abstract Task Execute(Message message, ITelegramBotClient client);

        public abstract bool Contains(Message message);
    }
}
