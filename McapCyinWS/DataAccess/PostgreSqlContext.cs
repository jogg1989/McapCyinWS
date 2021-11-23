using McapCyinWS.Models;
using Microsoft.EntityFrameworkCore;

namespace McapCyinWS.DataAccess
{
    public class PostgreSqlContext : DbContext
    {
        public DbSet<CatPersonal> catPersonal { get; set; }

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) { }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
