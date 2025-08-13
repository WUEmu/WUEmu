using System.Collections.Generic;
using MoonSharp.Interpreter;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Scripting
{
    [MoonSharpUserData]
    public class ScriptedItem : Item
    {
        private readonly string _scriptName;
        private readonly ScriptWorld _world;
        private Script script;
        private Table gameObject;

        public ScriptedItem(string scriptName)
        {
            _scriptName = scriptName;
            Initialize();
        }

        public void Initialize()
        {
            var gameScript = new GameScript("Item");
            gameObject = gameScript.GameObject;
            script = gameScript;
            script.DoFile(_scriptName);

            var initFunc = gameScript.GameObject.Get("Initialize").Function;
            initFunc.Call(this);
        }
        
        public void SetModel(string model) => Model = model;

        public void SetName(string name) => Name = name;
        
        public void SetHoverText(string text) => HoverText = text;

        public void SetRarity(byte rarity) => Rarity = rarity;

        public void SetIcon(int icon) => Icon = (short)icon;
        
        public override IList<ContextMenuEntry> GetContextMenu(ClientSession session)
        {
            var baseList = base.GetContextMenu(session);
            baseList.Add(new ContextMenuEntry(9999, "(RELOAD SCRIPT)"));
            
            var fn = gameObject.Get("GetContextMenu").Function;
            if (fn == null)
                return baseList;
            
            var menuItems = fn.Call(this, session.Player).Table;
            foreach (var x in menuItems.Values)
            {
                var item = x.Table;
                baseList.Add(new ContextMenuEntry((short)item.Get("Id").Number, item.Get("Caption").String));
            }

            return baseList;
        }

        public override void OnMenuItemClick(ClientSession session, short itemId)
        {
            if (itemId == 9999)
            {
                Initialize();
                session.Player.SendMessage(":Script", $"Script reloaded for {Name}", 0f, 1f, 0f);
                return;
            }
            
            base.OnMenuItemClick(session, itemId);
            
            var fn = gameObject.Get("MenuItemClick").Function;
            fn?.Call(this, session.Player, itemId);
        }

        public override void OnPlaced(Player player)
        {
            var fn = gameObject.Get("Placed").Function;
            fn?.Call(this, player);
        }
    }
}
