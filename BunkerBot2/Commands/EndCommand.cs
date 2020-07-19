using System.Threading.Tasks;
using BunkerBot2.Abstractions;
using Telegram.Bot;
using Bot1;

namespace BunkerBot2.Commands
{
    public class EndCommand : TelegramCommand
    {
        public override string Name => "/end";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            Program.ClearList();
        }
    }
}