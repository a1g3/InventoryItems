using Microsoft.EntityFrameworkCore;

namespace InventoryItems.Data.Infastructure {
    public class Repository<TEntity>
           where TEntity : class {
        protected InventoryContext DataContext { get; }
        protected DbSet<TEntity> Db => DataContext.Set<TEntity>();

        public Repository(IDatabaseFactory factory) {
            this.DataContext = this.GetDataContext(factory);
        }

        public InventoryContext GetDataContext(IDatabaseFactory factory) {
            return factory.GetContext();
        }
    }
}
