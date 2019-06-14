using InventoryItems.Domain.Infastructure;

namespace InventoryItems.Domain.Enums {
    public enum MintType {
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Denver")]
        Denver,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Philidelphia")]
        Philidelphia,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "San Francisco")]
        SanFrancisco,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "West Point")]
        WestPoint
    }
}
