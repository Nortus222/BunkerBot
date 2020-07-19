using System.Threading.Tasks;
using Bot1;
using BunkerBot2.Abstractions;
using Telegram.Bot;

namespace BunkerBot2.Commands
{
    public class GameOverCommand : TelegramCommand
    {
        public override string Name => "/gameover";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            Program.DeleteRoom(user);
        }
    }
}