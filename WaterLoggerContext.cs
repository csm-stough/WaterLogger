using Microsoft.EntityFrameworkCore;
using WaterLogger.Models;

namespace WaterLogger
{
    public class WaterLoggerContext : DbContext
    {
        public DbSet<DrinkingWaterModel> Records { get; set; }
        public string DbPath { get; }

        public WaterLoggerContext(IConfiguration configuration)
        {
            DbPath = configuration.GetConnectionString("ConnectionString");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbPath);
        }
    }
}
