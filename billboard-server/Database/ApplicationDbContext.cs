using billboard_server.Models;
using Microsoft.EntityFrameworkCore;

namespace billboard_server.Database
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ISettings _settings;

        public ApplicationDbContext(ISettings settings)
        {
            _settings = settings;
        }

        public DbSet<SongHit> SongHits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_settings.DbConnectionString);
        }
    }
}