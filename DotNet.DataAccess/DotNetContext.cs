using DotNet.Models;
using Microsoft.EntityFrameworkCore;

using System.Data.SqlClient;

namespace DotNet.DataAccess
{
    public class DotNetContext : DbContext
    {
        public DotNetContext(DbContextOptions<DotNetContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "donau.hiof.no",
                InitialCatalog = "nikolams",
                UserID = "nikolams",
                Password = "jC2mU38W",
                MultipleActiveResultSets = true,
                IntegratedSecurity = false
            };

            optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>()
                .HasKey(game => new { game.GameId, game.PublisherId, game.DeveloperId, game.CharacterId });
            modelBuilder.Entity<VideoGame>()
                .HasOne(vg => vg.Game)
                .WithOne(g => g.PartOf);
            modelBuilder.Entity<VideoGame>()
                .HasOne(vg => vg.Developer)
                .WithOne(dev => dev.DeveloperOf);
            modelBuilder.Entity<VideoGame>()
                .HasOne(vg => vg.Publisher)
                .WithOne(pub => pub.PublisherOf);
            modelBuilder.Entity<VideoGame>()
                .HasOne(vg => vg.Character)
                .WithOne(ch => ch.PartOf);

        }
    }
}
