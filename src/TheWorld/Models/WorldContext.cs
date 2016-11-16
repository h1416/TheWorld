using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TheWorld.Models
{
    public class WorldContext : DbContext
    {
        private IConfigurationRoot _config;
        private DbContextOptions _options;

        public WorldContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
            _options = options;
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:WorldContextConnection"]);
        }
    }
}
