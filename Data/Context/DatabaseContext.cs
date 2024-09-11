using Fiap.Api.WasteManagementApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Fiap.Api.WasteManagementApplication.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<GarbageCollection> GarbageCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GarbageCollection>(entity =>
            {
                entity.ToTable("T_GarbageCollection");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Address).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
