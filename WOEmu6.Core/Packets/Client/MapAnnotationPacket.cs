using System;
using System.Collections.Generic;
using Serilog;
using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Packets.Client
{
    public class MapAnnotationPacket : IIncomingPacket
    {
        // TODO: THIS MUST BE REMOVED IN THE FUTURE!!
        public static long AnnotationCounter = 0;
        
        public byte Opcode => -43 & 0xFF;
        
        public MapAnnotationCommand Command { get; private set; }
        
        public MapAnnotation Annotation { get; private set; }
        
        public void Read(PacketReader reader)
        {
            Command = (MapAnnotationCommand)reader.ReadByte();

            switch (Command)
            {
                case MapAnnotationCommand.Create:
                {
                    var type = (MapAnnotationType)reader.ReadByte();
                    var name = reader.ReadShortPrefixedString();
                    var server = reader.ReadShortPrefixedString();
                    var x = reader.ReadInt();
                    var y = reader.ReadInt();
                    var icon = reader.ReadByte();
                    Annotation = new MapAnnotation(AnnotationCounter++, type, new Position2D<int>(x, y), name, server, icon);
                    break;
                }
                
                case MapAnnotationCommand.Delete:
                    var id = reader.ReadLong();
                    var xxx = (MapAnnotationType)reader.ReadByte();
                    Annotation = new MapAnnotation(id, xxx, new Position2D<int>(0, 0), null, null, 0);
                    break;

                case MapAnnotationCommand.GetPermissions:
                    break;
            }
        }

        public void Handle(ClientSession client)
        {
            Console.WriteLine(Command);
            if (Command == MapAnnotationCommand.GetPermissions)
                client.Send(new SetMapAnnotationPermissions(true, true));
            else if (Command == MapAnnotationCommand.Create)
            {
                client.Send(new AddMapAnnotationsPacket(new List<MapAnnotation>
                {
                    Annotation
                }));
            }
            else if (Command == MapAnnotationCommand.Delete)
            {
                Log.Debug($"Deleting annotation {Annotation.Id}");
            }
        }
    }
}