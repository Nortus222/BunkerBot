using System.Threading.Tasks;
using BunkerBot2.Abstractions;
using Telegram.Bot;

namespace BunkerBot2.Commands
{
    public class CreateCards : TelegramCommand
    {
        public CreateCards()
        {
        }

        public override string Name => "/createcards";

        public override Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            throw new System.NotImplementedException();
        }
    }
}