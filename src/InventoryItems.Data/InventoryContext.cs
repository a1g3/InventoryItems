using InventoryItems.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryItems.Data {
    public class InventoryContext : DbContext {
        public InventoryContext() {}
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Items> Items { get; set; }
        public DbSet<ItemProperties> ItemProperties { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=InventoryDB;Trusted_Connection=True;");
        }
    }
}
