using System;
using System.Collections.Generic;
using Serilog;

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
            RegisterCommand("music", new PlayMusicCommand());
            RegisterCommand("book", new BookTestCommand());
            RegisterCommand("fartiles", new FarTilesCommand());
            RegisterCommand("recon", new ReconnectCommand());
            RegisterCommand("reload", new ReloadCommand());
            RegisterCommand("exec", new ScriptCommand());
        }

        public void RegisterCommand(string command, IChatCommand handler)
        {
            lock (commandsLock)
                commands.Add(command, handler);
            Log.Debug("Command registered: /{command}", command);
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
