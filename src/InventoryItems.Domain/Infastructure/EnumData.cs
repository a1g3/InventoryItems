using System;

namespace InventoryItems.Domain.Infastructure {
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public class EnumDataAttribute : Attribute {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
