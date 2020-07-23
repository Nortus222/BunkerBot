using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bot1;
using BunkerBot2.Abstractions;
using Telegram.Bot;

namespace BunkerBot2.Commands
{
    public class CreateCardsCommand : TelegramCommand
    { 
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
                        var netclient = new HttpClient();
                        
                        var cataclysm = await netclient.GetStringAsync("https://randomall.ru/api/custom/gen/1422/");
                        var cataclysm2 = cataclysm.Substring(9, cataclysm.Length - 11);
                        cataclysm2 += "\n";
                        string[] cataclysm3 = cataclysm2.Split("\\n");

                        foreach (var player in room.players)
                        {
                            string card_result = "+______Your___Card______+\n";
                            
                            var characteristics = await netclient.GetStringAsync("https://randomall.ru/api/custom/gen/758/");//1440, 758 (choose the best one)

                            card_result += "-----CHARACTERISTICS-----\n";
                            
                            string characteristics2 = characteristics.Substring(9, characteristics.Length - 11);
                            characteristics2 += "\n";
                            String[] characteristics3 = characteristics2.Split("\\n");
                            foreach (var word in characteristics3)
                            {
                                card_result += word + "\n";
                            }
                            card_result += "-------------------------\n";
                            
                            card_result += "--------CATACLYSM--------\n";
                            
                            foreach (var word in cataclysm3)
                            {
                                card_result += word + "\n";
                            }
                            card_result += "-------------------------\n";
                            
                            card_result+= "+_______________________+\n";
                            Program.SendMessage(player,card_result);
                        }
                    }
                }
                
            }
        }
        // private List<string> CreateCard()
        // {
        //     var random = new Random();
        //     string age = ListsForCards.ages[random.Next(ListsForCards.ages.Count)];
        //     string sex = ListsForCards.sex[random.Next(ListsForCards.sex.Count)];
        //     List<string> card = new List<string>(){age,sex};
        //     return card;
        // }
    }
}