using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WUEmu.Persistence.Entities
{
    public class PlayerData
    {
        [Key]
        public ulong SteamId { get; set; }
        [Key]
        public WorldData World { get; set; }
        
        public string Name { get; set; }
        
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        
        public float Rotation { get; set; }
        public byte Power { get; set; }
        public byte Layer { get; set; }
        
        public DateTime? LastLogin { get; set; }
    }
}
