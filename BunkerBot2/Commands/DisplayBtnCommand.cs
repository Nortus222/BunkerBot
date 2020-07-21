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
using BunkerBot2.Service;

namespace BunkerBot2.Commands
{
    public class DisplayBtnCommand: TelegramCommand
    {
        public DisplayBtnCommand()
        {
        }

        public override string Name { get; } = "/commands";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            CommandService commandsInstance = Program.GetCommands;
            List<TelegramCommand> commands ;

            if (user.IsHost)
            {
                commands = commandsInstance.GetAdmin();

            }else if(user.IsPlayer){

                commands = commandsInstance.GetPlayer();
            }
            else
            {
                commands = commandsInstance.GetNew();
            }


            int b = commands.Count % 2 == 0 ? commands.Count / 2 : commands.Count / 2 + 1;

            int count = 0;

            InlineKeyboardButton[][] buttons = new InlineKeyboardButton[b][];

            for (int i = 0; i < b; i++)
            {
                if (commands.Count % 2 != 0 && i == b - 1)
                {
                    buttons[i] = new[] { InlineKeyboardButton.WithCallbackData($"{commands[count].Name}") };

                }
                else
                {

                    buttons[i] = new[] {
                        InlineKeyboardButton.WithCallbackData($"{commands[count].Name}"),
                        InlineKeyboardButton.WithCallbackData($"{commands[count+1].Name}")
                    };
                    count += 2;
                }
            }

            var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(buttons);

            await client.SendTextMessageAsync(user.ChatID, "Choose option", replyMarkup: keyboard);
        }
    }
}
