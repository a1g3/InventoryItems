namespace InventoryItems.Data.Infastructure {
    public interface IDatabaseFactory {
        InventoryContext GetContext();
    }
}
