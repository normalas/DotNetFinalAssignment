using Microsoft.EntityFrameworkCore;
using DotNet.Models;
using System.Data.SqlClient;

namespace DotNet.DataAccess
{
    public class DotNetContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DotNetContext(DbContextOptions<DotNetContext> options) : base(options) { }
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

        }
    }
}
