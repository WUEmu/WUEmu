using NLua;
using WOEmu6.Core.Objects;
using Lua = KeraLua.Lua;

namespace WOEmu6.Core.Scripting
{
    public class ScriptedCreature : Creature
    {
        private readonly string creatureName;
        private readonly Lua lua;
        private readonly LuaThread thread;
        
        public ScriptedCreature(string name)
        {
            creatureName = name;
            ServerContext.Instance.Value.Lua.NewThread(out thread);
            lua = thread.State;
            //lua["World"] = new ScriptWorld(world);
            
            ServerContext.Instance.Value.Lua.XMove(lua, new ScriptWorld(ServerContext.Instance.Value.World));
            lua.SetGlobal("World");
            
            
            // Call the initialize method
            lua.GetGlobal(name);
            lua.PushString("Initialize");
            lua.GetTable(-2);
            PushSelf();
            lua.Call(1, 0);
        }

        public void PushSelf() => ServerContext.Instance.Value.Lua.XMove(lua, this);

        public void SetModel(string model) => Model = model;

        public void SetName(string name) => Name = name;

        public void SetHoverText(string text) => HoverText = text;

        public void SetRarity(byte rarity) => Rarity = rarity;

        public void SetCreatureType(byte type) => CreatureType = type;

        // public override IList<ContextMenuEntry> GetContextMenu(ClientSession session)
        // {
        //     lua.GetGlobal(creatureName);
        //     lua.PushString("GetActions");
        //     lua.GetTable(-2);
        //     
        //     PushSelf();
        //     ServerContext.Instance.Value.Lua.XMove(lua, session.Player);
        //     lua.Call(2, 1);
        //
        //     var res = new List<ContextMenuEntry>();
        //     while (lua.Next(-2))
        //     {
        //         dict[_translator.GetObject(_luaState, -2)] = _translator.GetObject(_luaState, -1);
        //         _luaState.SetTop(-2);
        //     }
        // }
    }
}