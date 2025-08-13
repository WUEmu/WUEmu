using MoonSharp.Interpreter;

namespace WOEmu6.Core.Objects
{
    [MoonSharpUserData]
    public class ChatMessage
    {
        public ChatMessage(Player sender, string channel, string text)
        {
            Sender = sender;
            Channel = channel;
            Text = text;
        }
        
        public Player Sender { get; }

        public string Channel { get; }
        
        public string Text { get; }
    }
}