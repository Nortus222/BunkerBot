using System;
using Telegram.Bot;
using System.Collections.Generic;
using Telegram.Bot.Args;
using BunkerBot2.Abstractions;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Bot1;
using BunkerBot2.Lists;

namespace BunkerBot2.Commands
{
    public class PlayersCommand: TelegramCommand
    {
        public PlayersCommand()
        {
        }

        public override string Name { get; } = "/players";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            List<Room> rooms  = Program.rooms.Rooms;

            foreach(Room room in rooms)
            {
                if (room.ContainsUser(user))
                {
                    string message = "Players in your room:";

                    foreach(BunkerUser player in room.Players)
                    {
                        message += $"\n{player.NickName}";
                    }

                    await client.SendTextMessageAsync(user.ChatID, message);
                }
            }

        }
    }
}
