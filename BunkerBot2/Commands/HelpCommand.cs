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
            string message; //= " /start - start a bot \n /host - to became a host of the game \n /join - to join the game \n /quit - deletes you from bot memory \n /end - deletes all users from bot memory ";
            if(user.IsHost)
            {
                message = " /players - show players in your room\n /vote - choose who to expel\n /quit - leave the room\n /end - delete all users from bot memory\n /gameover - close room\n /createcards - create cards for all players in the room";
            }
            else if(user.IsPlayer)
            {
                message = " /players - show players in your room\n /quit - leave the room\n /end - delete all users from bot memory";
            }
            else
            {
                message = " /end - delete all users from bot memory\n /host - create a room and become a host\n /join - join the room";
            }

            await client.SendTextMessageAsync(user.ChatID, message);
        }
    }
}
