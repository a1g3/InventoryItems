namespace InventoryItems.Domain.Interfaces.Infastructure {
    public interface ISettings {
        string TokenSecurityKey { get; set; }
        string Domain { get; set; }
    }
}
