using System;
using System.Collections.Generic;
using Serilog;
using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Client
{
    public class BmlResponsePacket : IIncomingPacket
    {
        public byte Opcode => 106;
        
        /// <summary>
        /// The ID of the button pressed by the player.
        /// </summary>
        public string ButtonId { get; private set; }
        
        /// <summary>
        /// A dictionary containing the values entered by the player, where the key is the control key and the value is the value.
        /// </summary>
        public IReadOnlyDictionary<string, string> Parameters { get; private set; }
        
        public void Read(PacketReader reader)
        {
            byte verifier = reader.ReadByte();
            ButtonId = reader.ReadBytePrefixedString();
            var parameterCount = reader.ReadShort();

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            for (var i = 0; i < parameterCount; i++)
            {
                var key = reader.ReadBytePrefixedString();
                var value = reader.ReadShortPrefixedString();
                parameters.Add(key, value);
            }

            Parameters = parameters;
        }

        public void Handle(ClientSession client)
        {
            Log.Debug("Player submitted a BML form!");
            Log.Debug(" - Button: {0}", ButtonId);
            foreach (var kvp in Parameters)
                Log.Debug(" * {0}: {1}", kvp.Key, kvp.Value);
        }
    }
}