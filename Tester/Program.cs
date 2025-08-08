using System.Net;
using System.Net.Sockets;
using System.Text;
using WO.Core;
using WOEmu6.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Client;

namespace Tester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var server = new Server();
            server.Run();
        }

        private static void HandleClient(TcpClient client)
        {
            /*
             * 123f
               00d7
             */

            // var clientSession = new ClientSession(client);
            // clientSession.Run();            

            Console.WriteLine("Connection received!");
            var stream = client.GetStream();
            var encryption = new Encryption();
            var incomingPacketFactory = new IncomingPacketFactory();

            while (true)
            {
                var p0 = new byte[2];
                stream.ReadExactly(p0, 0, 2);
                encryption.Decrypt(p0);
                var lenPacketReader = new PacketReader(p0);
                var len = lenPacketReader.PopShort();

                var p1 = new byte[len];
                stream.ReadExactly(p1, 0, len);
                encryption.Decrypt(p1);

                var reader = new PacketReader(p1);
                var opcode = reader.ReadByte();

                var packet = incomingPacketFactory.Get(opcode);
                if (packet == null)
                {
                    Console.WriteLine($"Unimplemented opcode {opcode}");
                    continue;
                }
                
                packet.Read(reader);
                
                
                
                switch (opcode)
                {
                    case 0xCC:
                    {
                        // var steamIdLength = reader.ReadByte();
                        // var steamId = Encoding.ASCII.GetString(reader.ReadBytes(steamIdLength));
                        // Console.WriteLine(steamId);

                        // var authTicket = reader.PopLong();
                        // var ticketArrayLength = reader.PopInt();
                        // var tickets = new List<byte>();
                        // for (var i = 0; i < ticketArrayLength; i++)
                            // tickets.Add(reader.ReadByte());
                        // var tokenLen = reader.PopLong();

                        // Write response
                        // var writer = new PacketWriter();
                        // writer.PushByte(0xCC);
                        // writer.PushByte(1);
                        // writer.PushShort(0);
                        // var toWrite = writer.Finish();
                        // encryption.Encrypt(toWrite, 0, toWrite.Length);
                        // stream.Write(toWrite);

                        // stream.Flush();

                        break;
                    }

                    case 0xF1:
                    {
                        Console.WriteLine("Logging in now");
                        var version = reader.PopInt();
                        var nameLength = reader.ReadByte();
                        var name = Encoding.ASCII.GetString(reader.ReadBytes(nameLength));
                        var passLength = reader.ReadByte();
                        var password = Encoding.ASCII.GetString(reader.ReadBytes(passLength));
                        var serverPasswordLength = reader.ReadByte();
                        var serverPassword = Encoding.ASCII.GetString(reader.ReadBytes(serverPasswordLength));

                        var steamIdLength = reader.ReadByte();
                        var steamId = Encoding.ASCII.GetString(reader.ReadBytes(steamIdLength));

                        var isExtraTileData = reader.ReadByte();
                        Console.WriteLine("User: {0}", name);

                        var writer = new PacketWriter();
                        writer.PushByte(0xF1);
                        writer.PushByte(1);
                        var msg = Encoding.UTF8.GetBytes("Welcome to... WOEmu 5.0. It's been 84 years.");
                        writer.PushShort((short)msg.Length);
                        writer.PushBytes(msg);
                        writer.PushByte(0); // on surface
                        writer.PushLong(0x0000000014DEC241L); // time
                        writer.PushLong(0); // millis
                        writer.PushFloat(0); //rot
                        writer.PushFloat(0); // x
                        writer.PushFloat(0); // y
                        writer.PushFloat(50); // z
                        
                        var model = Encoding.UTF8.GetBytes("Human");
                        writer.PushShort((short)model.Length);
                        writer.PushBytes(model);
                        
                        //power
                        writer.PushByte(1);

                        writer.PushByte(0); // command type (for vehicles?)
                        writer.PushShort(10); // retry seconds?
                        writer.PushLong(0);//face
                        writer.PushByte(0); //kingdom template
                        writer.PushInt(0); //teleport counter
                        writer.PushByte(1); //blood?
                        writer.PushLong(0); // bridge id
                        writer.PushFloat(3); //ground offset
                        writer.PushInt(32); // tile size X
                        
                        var toWrite = writer.Finish();
                        encryption.Encrypt(toWrite, 0, toWrite.Length);
                        stream.Write(toWrite);
                        stream.Flush();
                        
                        // Send weather
                        var weatherWriter = new PacketWriter();
                        weatherWriter.PushByte(46);
                        weatherWriter.PushFloat(0f);
                        weatherWriter.PushFloat(0f);
                        weatherWriter.PushFloat(0f);
                        weatherWriter.PushFloat(0f);
                        weatherWriter.PushFloat(0f);
                        var weatherData = weatherWriter.Finish();
                        encryption.Encrypt(weatherData, 0, weatherData.Length);
                        stream.Write(weatherData);
                        stream.Flush();
                        
                        // Send sleep info
                        var sleepWriter = new PacketWriter();
                        sleepWriter.PushByte(1);
                        sleepWriter.PushByte(1);
                        sleepWriter.PushInt(500);
                        var sleepData = sleepWriter.Finish();
                        encryption.Encrypt(sleepData, 0, sleepData.Length);
                        stream.Write(sleepData);
                        stream.Flush();
                        
                        // Send map info
                        var mapInfo = new PacketWriter();
                        mapInfo.PushByte(0xAD);
                        var serverName = Encoding.UTF8.GetBytes("WOEmu 6.0 prototype");
                        mapInfo.PushByte((byte)serverName.Length);
                        mapInfo.PushBytes(serverName);
                        mapInfo.PushByte(1);
                        var mapInfoData = mapInfo.Finish();
                        encryption.Encrypt(mapInfoData, 0, mapInfoData.Length);
                        stream.Write(mapInfoData);
                        stream.Flush();

                        // var a = new PacketWriter();
                        // a.PushByte((byte)0x94);
                        // var aData = a.Finish();
                        // encryption.Encrypt(aData, 0, aData.Length);
                        // stream.Write(aData);
                        // stream.Flush();
                        
                        // Send speed (32)
                        // var speedWriter = new PacketWriter();
                        // speedWriter.PushByte(32);
                        // speedWriter.PushFloat(1.0f);
                        // var xxx = speedWriter.Finish();
                        // encryption.Encrypt(xxx, 0, xxx.Length);
                        // stream.Write(xxx);
                        // stream.Flush();
                        //
                        // // Send start moving
                        // var startMoving = new PacketWriter();
                        // startMoving.PushByte((byte)0x9C);
                        // var startMovingBytes = startMoving.Finish();
                        // encryption.Encrypt(startMovingBytes, 0, startMovingBytes.Length);
                        // stream.Write(startMovingBytes);
                        // stream.Flush();

                        var terrain = new PacketWriter();
                        terrain.PushByte(73);
                        terrain.PushByte(0); //water
                        terrain.PushByte(1); //extra
                        terrain.PushShort(-10); // y
                        terrain.PushShort(302); // w
                        terrain.PushShort(1);   // h
                        terrain.PushShort(-10); // x

                        for (int i = 0; i < 302; i++)
                        {
                            terrain.PushInt(25);
                            terrain.PushByte(2);
                        }
                        // terrain.PushInt(4);
                        // terrain.PushInt(4);
                        // terrain.PushInt(4);

                        var terrainData = terrain.Finish();
                        encryption.Encrypt(terrainData, 0, terrainData.Length);
                        stream.Write(terrainData);
                        stream.Flush();
                        
                        // Send speed (32)
                        var speedWriter = new PacketWriter();
                        speedWriter.PushByte(32);
                        speedWriter.PushFloat(1.0f);
                        var xxx = speedWriter.Finish();
                        encryption.Encrypt(xxx, 0, xxx.Length);
                        stream.Write(xxx);
                        stream.Flush();
                        
                        var startMoving = new PacketWriter();
                        startMoving.PushByte((byte)0x9C);
                        var startMovingBytes = startMoving.Finish();
                        encryption.Encrypt(startMovingBytes, 0, startMovingBytes.Length);
                        stream.Write(startMovingBytes);
                        stream.Flush();
                        
                        break;
                    }

                    case 0x63: // chat
                    {
                        var messageLen = reader.ReadByte();
                        var message = Encoding.UTF8.GetString(reader.ReadBytes(messageLen));

                        var titleLen = reader.ReadByte();
                        var title = Encoding.UTF8.GetString(reader.ReadBytes(titleLen));
                        
                        Console.WriteLine($"{title}> {message}");
                        
                        break;
                    }

                    case 36: // move
                    {
                        // var id = reader.PopLong();
                        // var y = reader.PopFloat();
                        // var x = reader.PopFloat();
                        // var rot = reader.PopByte();

                        var x = reader.PopFloat();
                        var y = reader.PopFloat();
                        var z = reader.PopFloat();
                        var rot = reader.PopFloat();
                        var bm = reader.ReadByte();
                        var layer = reader.ReadByte();
                        
                        Console.WriteLine($"{x},{y},{z} rot={rot}");

                        var ack = new PacketWriter();
                        ack.PushByte(72);
                        ack.PushLong(0);
                        ack.PushFloat(z);
                        ack.PushFloat(x);
                        ack.PushByte(0);
                        ack.PushFloat(y);
                        var ackData = ack.Finish();
                        encryption.Encrypt(ackData, 0, ackData.Length);
                        stream.Write(ackData);
                        stream.Flush();
                        
                        break;
                    }

                    case 51: // teleport
                    {
                        var counter = reader.PopInt();
                        
                        /*
                         * float x = bb.getFloat();
                            float y = bb.getFloat();
                            float h = bb.getFloat();
                            float yRot = bb.getFloat();
                            boolean isLocal = (bb.get() != 0);
                            int layer = bb.get();
                            boolean disembark = (bb.get() != 0);
                            byte commandType = bb.get();
                            int counter = bb.getInt();
                            if (!isLocal)
                              this.serverConnectionListener.setDead(false); 
                         */
                        

                        var writer = new PacketWriter();
                        writer.PushByte(51);
                        writer.PushFloat(0);
                        writer.PushFloat(0);
                        writer.PushFloat(30);
                        writer.PushFloat(0);
                        writer.PushByte(0);
                        writer.PushByte(0);
                        writer.PushByte(0); //disembark
                        writer.PushByte(0);
                        writer.PushInt(counter);
                        
                        var data = writer.Finish();
                        encryption.Encrypt(data, 0, data.Length);
                        stream.Write(data);
                        stream.Flush();
                        
                        
                        
                        break;
                    }
                    
                    default:
                        Console.WriteLine("Unimplemented opcode {0}", opcode);
                        break;
                }
            }
        }
    }
}