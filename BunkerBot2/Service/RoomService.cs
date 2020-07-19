using System.Collections.Generic;
using BunkerBot2.Abstractions;
using BunkerBot2.Commands;

namespace BunkerBot2.Service
{
    public class RoomService
    {
        public static readonly List<TelegramCommand> commands = new List<TelegramCommand>
        {
            new ConnectCommand()
        };

    }
}