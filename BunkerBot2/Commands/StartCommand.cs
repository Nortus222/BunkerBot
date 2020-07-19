using System;
using System.Threading.Tasks;
using BunkerBot2.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BunkerBot2.Commands
{
    public class StartCommand: TelegramCommand
    {
        public StartCommand()
        {
        }

        public override string Name { get; } = "/start";

        public override bool Contains(Message message)
        {
            if (message.Type != MessageType.Text)
            {
                return false;
            }
           
            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, ITelegramBotClient client)
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
                                InlineKeyboardButton.WithCallbackData("/host")
                            }
                        }
                    ) ;

            await client.SendTextMessageAsync(message.Chat.Id, "Choose option", replyMarkup: keyboard);
        }
    }
}
