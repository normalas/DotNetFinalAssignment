using DotNet.Models;
using Microsoft.EntityFrameworkCore;

using System.Data.SqlClient;

namespace DotNet.DataAccess
{
    public class DotNetContext : DbContext
    {
        public DotNetContext(DbContextOptions<DotNetContext> options) : base(options) { }

        public DbSet<VideoGame> VideoGames { get; set; }


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
                .HasKey(game => new { game.GameId});

        }
    }
}
