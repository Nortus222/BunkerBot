using System;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using BunkerBot2.Abstractions;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace BunkerBot2.Commands
{
    public class HelpCommand: TelegramCommand
    {
        public HelpCommand()
        {
        }

        public override string Name { get; } = "/help";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            string message = " /start - start a bot /n /host - to became a host of the game /n /join - to join the game ";

            await client.SendTextMessageAsync(user.ChatID, message);
        }
    }
}
