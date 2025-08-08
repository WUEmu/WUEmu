using System;
using System.Collections.Generic;

namespace WOEmu6.Core.Commands
{
    public class CommandRepository
    {
        private static object commandsLock = new();
        private readonly Dictionary<string, IChatCommand> commands;
        
        public CommandRepository()
        {
            commands = new Dictionary<string, IChatCommand>();
            
            RegisterCommand("tp", new TeleportCommand());
            RegisterCommand("speed", new SetSpeedCommand());
            RegisterCommand("weather", new WeatherCommand());
            RegisterCommand("item", new SpawnItem());
            RegisterCommand("music", new PlayMusicCommand());
            RegisterCommand("book", new BookTestCommand());
            RegisterCommand("fartiles", new FarTilesCommand());
        }

        public void RegisterCommand(string command, IChatCommand handler)
        {
            lock (commandsLock)
                commands.Add(command, handler);
            Console.WriteLine($"Command registered: /{command}");
        }

        public IChatCommand GetCommand(string command)
        {
            lock (commandsLock)
            {
                if (commands.TryGetValue(command.TrimStart('/'), out var handler))
                    return handler;
            }

            return null;
        }
    }
}
