using InventoryItems.Domain.Infastructure;

namespace InventoryItems.Domain.Enums {
    public enum Country {
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "United States")]
        UnitedStates,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Canada")]
        Canada
    }
}
