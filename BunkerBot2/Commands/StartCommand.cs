using System;
using System.Threading.Tasks;
using BunkerBot2.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Bot1;
using BunkerBot2.Service;

namespace BunkerBot2.Commands
{
    public class StartCommand: TelegramCommand
    {
        public StartCommand()
        {
        }

        public override string Name { get; } = "/start";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            CommandService commands = Program.GetCommands;

            int b = commands.Get().Count % 2 == 0 ? commands.Get().Count / 2 : commands.Get().Count / 2 + 1;
            
            int count = 0;

            InlineKeyboardButton[][] buttons = new InlineKeyboardButton[b][];

            for (int i = 0; i < b; i++)
            {
                if (commands.Get().Count % 2 != 0 && i == b - 1)
                {
                    buttons[i] = new[] { InlineKeyboardButton.WithCallbackData($"{commands.Get()[count].Name}") };

                }
                else
                {

                    buttons[i] = new[] {
                        InlineKeyboardButton.WithCallbackData($"{commands.Get()[count].Name}"),
                        InlineKeyboardButton.WithCallbackData($"{commands.Get()[count+1].Name}")
                    };
                    count += 2;
                }
            }

            var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(buttons);

            await client.SendTextMessageAsync(user.ChatID, "Choose option", replyMarkup: keyboard);

            
            if(!Program.GetBunkerUsers.CheckExistance(user)) Program.GetBunkerUsers.Add(user);
            var tmp = Program.GetBunkerUsers.Users;
            string message = "Users Online:";
            foreach(var us in tmp)
            {
                message += $"\n{us.NickName}";
            }
            await client.SendTextMessageAsync(user.ChatID, message);
        }
    }
}
