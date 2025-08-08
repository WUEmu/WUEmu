using System;
using System.Collections.Generic;
using System.Linq;
using WO.Core;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    public class ContextMenuClickPacket : IIncomingPacket
    {
        public byte Opcode => 0x61;

        public IReadOnlyList<long> Targets { get; private set; }
        
        public short EntryId { get; private set; }
        
        public long Subject { get; private set; }

        public void Read(PacketReader reader)
        {
            var count = reader.PopShort();
            Subject = reader.PopLong();

            var target = new List<long>();
            for (var i = 0; i < count; i++)
                target.Add(reader.PopLong());
            Targets = target;
            
            EntryId = reader.PopShort();
        }

        public void Handle(ClientSession client)
        {
            // switch (EntryId)
            // {
            //     case 1:
            //         // make dirt
            //         Console.WriteLine("Turning tile into dirt!");
            //         foreach (var t in Targets)
            //         {
            //             var id = new WurmId(t);
            //             var coords = id.ToTileCoordinate();
            //             var tile = context.TopLayer.GetTileValue(coords.Item1, coords.Item2);
            //             tile.Type = TileType.Dirt;
            //             context.TopLayer.SetTileValue(coords.Item1, coords.Item2, tile);
            //              
            //             client.Send(new TileStripPacket(
            //                 coords.Item1, coords.Item2,
            //                 1, 1
            //             ));
            //         }
            //         break;
            //
            //     case 2:
            //     {
            //         foreach (var t in Targets)
            //         {
            //             var id = new WurmId(t);
            //             var coords = id.ToTileCoordinate();
            //             Console.WriteLine(t);
            //             Console.WriteLine(id.ToTileCoordinate());
            //             var tile = context.TopLayer.GetTileValue(coords.Item1, coords.Item2);
            //             tile.Type = TileType.Cobblestone;
            //             context.TopLayer.SetTile(coords.Item1, coords.Item2, tile);
            //              
            //             client.Send(new TileStripPacket(
            //                 coords.Item1, coords.Item2,
            //                 1, 1
            //             ));
            //         }
            //
            //         break;
            //     }
            //
            //     case 3:
            //     {
            //         foreach (var t in Targets)
            //         {
            //             var id = new WurmId(t);
            //             var coords = id.ToTileCoordinate();
            //             var tile = context.TopLayer.GetTileValue(coords.Item1, coords.Item2);
            //             tile.Height += 10;
            //             context.TopLayer.SetTile(coords.Item1, coords.Item2, tile);
            //              
            //             client.Send(new TileStripPacket(
            //                 coords.Item1, coords.Item2,
            //                 1, 1
            //             ));
            //         }
            //         break;
            //     }
            //
            //     case 5:
            //     {
            //         var target = Targets.Single();
            //         var id = new WurmId(target);
            //         var centerCoords = id.ToTileCoordinate();
            //         var centerTile = context.TopLayer.GetTileValue(centerCoords.Item1, centerCoords.Item2);
            //
            //         for (var x = -10; x < 10; x++)
            //         {
            //             for (var y = -10; y < 10; y++)
            //             {
            //                 var xTarget = centerCoords.Item1 + x;
            //                 var yTarget = centerCoords.Item2 + y;
            //                 var tile = context.TopLayer.GetTileValue(xTarget, yTarget);
            //                 tile.Height = centerTile.Height;
            //                 context.TopLayer.SetTileValue(xTarget, yTarget, tile);
            //             }
            //         }
            //
            //         client.Send(new TileStripPacket((short)(centerCoords.Item1 - 10), (short)(centerCoords.Item2 - 10), 20, 20));
            //         break;
            //     }
            // }
        }
    }
}