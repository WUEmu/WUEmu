using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Zones;

namespace WOEmu6.Core.Scripting
{
    [MoonSharpUserData]
    public class ScriptedItem : Item
    {
        private readonly ScriptWorld _world;
        private readonly string creatureName;
        private readonly Script script;
        private readonly Table gameObject;

        public ScriptedItem(string scriptName)
        {
            var gameScript = new GameScript("Item");
            gameObject = gameScript.GameObject;
            script = gameScript;
            script.DoFile(scriptName);

            var initFunc = gameScript.GameObject.Get("Initialize").Function;
            initFunc.Call(this);
        }
        
        public void SetModel(string model) => Model = model;

        public void SetName(string name) => Name = name;
        
        public void SetHoverText(string text) => HoverText = text;

        public void SetRarity(byte rarity) => Rarity = rarity;

        public void SetIcon(short icon) => Icon = icon;
        
        public override IList<ContextMenuEntry> GetContextMenu(ClientSession session)
        {
            var baseList = base.GetContextMenu(session);
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
            base.OnMenuItemClick(session, itemId);
            
            var fn = gameObject.Get("MenuItemClick").Function;
            fn?.Call(this, session.Player, itemId);
        }
    }
}