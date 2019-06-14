using InventoryItems.Domain.Infastructure;

namespace InventoryItems.Domain.Enums {
    public enum CoinType {
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Cent")]
        Cent,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Nickel")]
        Nickel,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Dime")]
        Dime,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Quarter")]
        Quarter,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Half Dollar")]
        HalfDollar,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Small Dollar")]
        SmallDollar,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Large Dollar")]
        LargeDollar
    }
}
