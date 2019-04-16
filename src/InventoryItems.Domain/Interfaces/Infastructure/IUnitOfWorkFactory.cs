namespace InventoryItems.Domain.Interfaces.Infastructure {
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork();
    }
}
