using System;
using MoonSharp.Interpreter;

namespace WOEmu6.Core.Utilities
{
    public static class EnumToLuaTable
    {
        public static Table Create<T>(Script s)
        {
            var t = new Table(s);
            foreach (var value in Enum.GetValues(typeof(T)))
                t[value.ToString()] = (int)value;
            return t;
        }
    }
}