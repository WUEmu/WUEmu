using System;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Actions
{
    public class TerraformDirt : TimedAction<Tile>
    {
        public override short ActionId => 2000;

        public override TimeSpan GetDuration(ClientSession client, Tile target) => TimeSpan.FromSeconds(3);

        public override void OnTimerFinished(ClientSession client, Tile target)
        {
            target.TileType = TileType.Dirt;
            target.CommitChanges();
            client.Send(new TileStripPacket(target.X, target.Y, 1, 1 ));
        }

        public override string GetActionText(ClientSession client, Tile target) => "Terraforming into dirt";
    }
}
