using InventoryItems.Domain.Interfaces.Infastructure;

namespace InventoryItems.Domain {
    public class Settings : ISettings {
        public string TokenSecurityKey { get; set; }
        public string Domain { get; set; }
    }
}
