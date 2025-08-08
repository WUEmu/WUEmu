using System.Globalization;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Commands
{
    public class WeatherCommand : IChatCommand
    {
        public bool Execute(ServerContext context, ClientSession client, string[] arguments)
        {
            // /weather <cloudiness> <fog> <rain> <windRot> <windPow>
            if (arguments.Length != 5)
                return false;

            client.Send(new UpdateWeatherPacket(
                float.Parse(arguments[0], CultureInfo.InvariantCulture),
                float.Parse(arguments[1], CultureInfo.InvariantCulture),
                float.Parse(arguments[2], CultureInfo.InvariantCulture),
                float.Parse(arguments[3], CultureInfo.InvariantCulture),
                float.Parse(arguments[4], CultureInfo.InvariantCulture)
            ));

            return true;
        }
    }
}