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
            new DisplayBtnCommand(),
            new HostCommand(),
            new JoinCommand(),
            new EndCommand(),
            new QuitCommand(),
            new GameOverCommand(),
            new PlayersCommand()
        };

        private readonly List<TelegramCommand> adminCommands = new List<TelegramCommand>
        {
            new HelpCommand(),
            new PlayersCommand(),
            new QuitCommand(),
            new EndCommand(),
            new GameOverCommand()
        };

        private readonly List<TelegramCommand> playerCommands = new List<TelegramCommand>
        {
            new HelpCommand(),
            new PlayersCommand(),
            new QuitCommand(),
            new EndCommand()
        };

        private readonly List<TelegramCommand> newUserCommands = new List<TelegramCommand>
        {
            new HelpCommand(),
            new EndCommand(),
            new HostCommand(),
            new JoinCommand()
        };

        public List<TelegramCommand> GetAll() => commands;

        public List<TelegramCommand> GetAdmin() => adminCommands;

        public List<TelegramCommand> GetPlayer() => playerCommands;

        public List<TelegramCommand> GetNew() => newUserCommands;

        public TelegramCommand GetDisplayCommand() => new DisplayBtnCommand();

        public TelegramCommand GetStartCommand() => new StartCommand();
        public TelegramCommand GetDisplayBtnCommand() => new DisplayBtnCommand();

    }
}
