
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class UpdateWeatherPacket : IOutgoingPacket
    {
        public float Cloudiness { get; }
        public float Fog { get; }
        public float Rain { get; }
        public float WindRotation { get; }
        public float WindPower { get; }

        public UpdateWeatherPacket(float cloudiness, float fog, float rain, float windRotation, float windPower)
        {
            Cloudiness = cloudiness;
            Fog = fog;
            Rain = rain;
            WindRotation = windRotation;
            WindPower = windPower;
        }
        
        public byte Opcode => 46;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteFloat(Cloudiness);
            writer.WriteFloat(Fog);
            writer.WriteFloat(Rain);
            writer.WriteFloat(WindRotation);
            writer.WriteFloat(WindPower);
        }
    }
}