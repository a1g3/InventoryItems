using InventoryItems.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryItems.Data {
    public class InventoryContext : DbContext {
        public InventoryContext() {}
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Coins> Coins { get; set; }
        public DbSet<Collections> Collections { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=InventoryDB;Trusted_Connection=True;");
        }
    }
}
