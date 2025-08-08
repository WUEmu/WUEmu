using System.IO;
using System.Linq;
using WOEmu6.Core.BML;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Commands
{
    public class BookTestCommand : IChatCommand
    {
        public bool Execute(ClientSession client, string[] arguments)
        {
            const string Title = "De Goudvis";
            string body = string.Empty;
            using (var fs = System.IO.File.Open("D:\\Temp\\goudvis.txt", FileMode.Open))
            {
                var reader = new StreamReader(fs);
                var contents = reader.ReadToEnd();
                var chunks = contents.Chunk(512).Select(arr => new string(arr)).ToArray();
                body = chunks[0];
            }
            

            var bml = $"varray{{center{{header{{text='{Title}';}}}}; text{{text='{body}'}} harray{{button{{text='Next';id='next';}}}}}}";
            var form = new BmlForm(0x1000, Title, bml);
            client.Send(new BmlFormPacket(form));
            return true;
        }
    }
}