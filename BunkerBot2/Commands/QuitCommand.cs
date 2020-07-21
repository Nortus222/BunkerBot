using System.Threading.Tasks;
using Bot1;
using BunkerBot2.Abstractions;
using Telegram.Bot;

namespace BunkerBot2.Commands
{
    public class QuitCommand : TelegramCommand
    {
        public override string Name => "/quit";

        public async override Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            foreach (var room in Program.GetRooms.Rooms)
            {
                if (room.Players.Contains(user))
                {
                    room.RemovePlayer(user);
                }
            }

            await client.SendTextMessageAsync(user.ChatID, "You have quited the room.\nJoin new one or create yours");
        }
    }
}