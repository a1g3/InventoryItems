using InventoryItems.Domain.Interfaces.Infastructure;

namespace InventoryItems.Data.Infastructure {
    public class UnitOfWorkFactory : IUnitOfWorkFactory {
        public IUnitOfWork GetUnitOfWork() => new UnitOfWork();
    }
}
