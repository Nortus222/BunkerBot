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
            //TODO Clear all the lists, remove all isHost flags (if its necessary, idk)
            Program.bunkerUsers.CLearBunkerUsersList();
            Program.rooms.ClearRoomList();

            await client.SendTextMessageAsync(user.ChatID, "All users has been deleted from the bot memory");
        }
    }
}