using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bot1;
using BunkerBot2.Abstractions;
using Telegram.Bot;

namespace BunkerBot2.Commands
{
    public class CreateCardsCommand : TelegramCommand
    {
        private List<string> CreateCard()
        {
            var random = new Random();
            string age = ListsForCards.ages[random.Next(ListsForCards.ages.Count)];
            string sex = ListsForCards.sex[random.Next(ListsForCards.sex.Count)];
            List<string> card = new List<string>(){age,sex};
            return card;
        }
        public CreateCardsCommand()
        {
        }

        public override string Name => "/createcards";

        public async override Task Execute(BunkerUser user, ITelegramBotClient client)
        {
            if(user.IsHost)
            {
                foreach(var room in Program.GetRooms.Rooms)
                {
                    if(room.Host == user)
                    {
                        foreach(var player in room.players)
                        {
                            player.Card = CreateCard();
                            string card_result = "+______Your___Card______+\n";
                            foreach (var word in player.Card)
                            {
                                card_result+=word+"\n";
                            }
                            card_result+= "+_______________________+\n";
                            Program.SendMessage(player,card_result);
                        }
                    }
                }
            }
        }
    }
}