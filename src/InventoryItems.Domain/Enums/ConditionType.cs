using InventoryItems.Domain.Infastructure;

namespace InventoryItems.Domain.Enums {
    public enum ConditionType {
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Good")]
        Good,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Very Good")]
        VeryGood,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Fine")]
        Fine,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Very Fine")]
        VeryFine,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Extremely Fine")]
        ExtremelyFine,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "About Uncirculated")]
        AboutUncirculated,
        [EnumData(Key = Constants.DISPLAY_NAME_KEY, Value = "Mint State")]
        MintState
    }
}
