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

namespace BunkerBot2.Commands
{
    public class JoinCommand: TelegramCommand
    {
        public JoinCommand()
        {
        }

        public override string Name { get; } = "/join";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            List<Room> roomList = Program.GetRooms();

            if(roomList == null || roomList.Count == 0)
            {
                return;
            }

            BunkerUser[] admins = new BunkerUser[roomList.Count];

            int count = 0;

            foreach(Room room in roomList)
            {
                admins[count] = room.GetHost();
                count++;
            }

            InlineKeyboardButton[] buttons = new InlineKeyboardButton[admins.Length];

            for(int i = 0; i < admins.Length; i++)
            {
                buttons[i] = InlineKeyboardButton.WithCallbackData($"{admins[i]}", "/connect");
            }

            var keyboard = new InlineKeyboardMarkup(buttons);

            await client.SendTextMessageAsync(user.ChatID, "Choose your host", replyMarkup: keyboard);
        }
    }
}
