using System;
using System.Threading.Tasks;
using BunkerBot2.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Bot1;

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
            var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(
                        new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[][]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("/help"),
                                InlineKeyboardButton.WithCallbackData("/start")

                            },
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("/host"),
                                InlineKeyboardButton.WithCallbackData("/join")
                            }
                        }
                    ) ;

            await client.SendTextMessageAsync(user.ChatID, "Choose option", replyMarkup: keyboard);

            
            if(!Program.GetBunkerUsers.CheckExistance(user)) Program.GetBunkerUsers.Add(user);
            var tmp = Program.GetBunkerUsers.Users;
            foreach(var us in tmp)
            {
                await client.SendTextMessageAsync(user.ChatID,(us.NickName));
            }  

        }
    }
}
