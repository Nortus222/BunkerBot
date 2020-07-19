using System;
using BunkerBot2.Commands;
using BunkerBot2.Abstractions;
using System.Collections.Generic;

namespace BunkerBot2.Service
{
    public class CommandService
    {
        private readonly List<TelegramCommand> commands;

        public CommandService()
        {
            commands = new List<TelegramCommand>
            {
                new HostCommand(),
                new StartCommand(),
                new JoinCommand(),
                new HelpCommand()
            };

        }

        public List<TelegramCommand> Get() => commands;

    }
}
