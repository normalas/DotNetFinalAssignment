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
                .HasKey(game => new { game.GameId, game.PublisherId, game.DeveloperId, game.CharacterId});

            modelBuilder.Entity<VideoGame>()
                .HasOne(vg => vg.Developer)
                .WithMany(game => game.DevelopedGames)
                .HasForeignKey(dev => dev.DeveloperId);
            modelBuilder.Entity<VideoGame>()
                .HasOne(pub => pub.Publisher)
                .WithMany(game => game.PublishedGames)
                .HasForeignKey(pub => pub.PublisherId);
        }
    }
}
