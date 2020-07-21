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

            await client.SendTextMessageAsync(user.ChatID, "Welcome to the game");

            if (!Program.GetBunkerUsers.CheckExistance(user))
            {
                
                Program.GetBunkerUsers.Add(user);
                await commands.GetDisplayCommand().Execute(user, client);
            }

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
