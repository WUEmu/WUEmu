using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Zones;

namespace WOEmu6.Core.Scripting
{
    [MoonSharpUserData]
    public class ScriptedCreature : Creature
    {
        private readonly string _scriptName;
        private Script script;
        private Table gameObject;
        
        public ScriptedCreature(string scriptName, Zone zone) : base(zone)
        {
            _scriptName = scriptName;
            Initialize();
        }

        public void Initialize()
        {
            var gameScript = new GameScript("Creature");
            gameObject = gameScript.GameObject;
            gameScript.GameObject["SetModel"] = (Action<string>)SetModel;
            script = gameScript;
            script.DoFile(_scriptName);

            var initFunc = gameScript.GameObject.Get("Initialize").Function;
            initFunc.Call(this);
        }

        public void SetModel(string model) => Model = model;

        public void SetName(string name) => Name = name;

        public void SetHoverText(string text) => HoverText = text;

        public void SetRarity(byte rarity) => Rarity = rarity;

        public void SetCreatureType(byte type) => CreatureType = type;

        public override IList<ContextMenuEntry> GetContextMenu(ClientSession session)
        {
            var baseList = base.GetContextMenu(session);
            baseList.Add(new ContextMenuEntry(9999, "(RELOAD SCRIPT)"));
            
            var fn = gameObject.Get("GetContextMenu").Function;
            var menuItems = fn.Call(this, DynValue.Nil).Table;
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
            fn.Call(this, session.Player, itemId);
        }
    }
}