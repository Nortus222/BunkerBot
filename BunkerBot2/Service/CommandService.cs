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
            new HelpCommand(),
            new StartCommand(),
            new HostCommand(),
            new JoinCommand(),
            new EndCommand(),
            new QuitCommand(),
            new GameOverCommand()
        };

        public List<TelegramCommand> Get() => commands;

    }
}
