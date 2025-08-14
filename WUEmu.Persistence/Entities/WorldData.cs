using System.ComponentModel.DataAnnotations;

namespace WUEmu.Persistence.Entities
{
    public class WorldData
    {
        [Key]
        public int WorldId { get; set; }
        
        public string Name { get; set; }
    }
}