using System;
using BunkerBot2.Commands;
using BunkerBot2.Abstractions;
using System.Collections.Generic;

namespace BunkerBot2.Service
{
    public class CommandService
    {
        private readonly List<TelegramCommand> commands = new List<TelegramCommand>
        {
            new HostCommand(),
            new StartCommand(),
            new JoinCommand(),
            new HelpCommand(),
            new EndCommand(),
            new QuitCommand()
        };

        public List<TelegramCommand> Get() => commands;

    }
}
