using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WUEmu.Persistence.Entities;

namespace WUEmu.Persistence
{
    public class WurmDbContext : DbContext
    {
        public DbSet<PlayerData> Players { get; set; }
        public DbSet<WorldData> Worlds { get; set; }

        public WurmDbContext(DbContextOptions<WurmDbContext> opts) : base(opts)
        {
        }

        public static PooledDbContextFactory<WurmDbContext> CreatePool(string connectionString)
        {
            return new PooledDbContextFactory<WurmDbContext>(new DbContextOptionsBuilder<WurmDbContext>()
                .UseNpgsql(connectionString)
                .Options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!EF.IsDesignTime)
                return;
            
            // This is only used for migration scaffolding, which uses the locla database server.
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=wuemu;Username=wuemu;Password=wuemu");
        }
    }
}
