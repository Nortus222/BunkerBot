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
using System.Timers;

namespace BunkerBot2.Commands
{
    public class VoteCommand: TelegramCommand
    {
        public VoteCommand()
        {
        }

        public override string Name { get; } = "/vote";

        public override async Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            Room room = Program.rooms.GetRoomByPlayer(user);

            int size = room.Players.Count;

            string[] options = new string[size];

            for (int i = 0; i < size; i++)
            {
                options[i] = $"{room.Players[i].NickName}";
            }

            var pollInt = await client.SendPollAsync(room.Players[0].ChatID, "Whom to quit", options);

            for (int i = 1; i< size; i++)
            {
                await client.ForwardMessageAsync(room.Players[i].ChatID, pollInt.Chat.Id, pollInt.MessageId);
            }

            await Task.Delay(20000);

            var stoppedPoll = await client.StopPollAsync(pollInt.Chat.Id, pollInt.MessageId);

            int max = 0;

            string name = "";

            foreach(PollOption option in stoppedPoll.Options)
            {
                if(option.VoterCount > max)
                {
                    max = option.VoterCount;
                    name = option.Text;
                }
            }

            BunkerUser player = room.GetPlayerByName(name);
            room.RemovePlayer(player);
            

            
        }
    }
}
