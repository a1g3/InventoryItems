using InventoryItems.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InventoryItems.Domain.Infastructure {
    public static class EnumHelper {
        public static object GetValue(this Enum value, string key) {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");

            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());
            List<EnumDataAttribute> enumData = fieldInfo.GetCustomAttributes(typeof(EnumDataAttribute), false).Select(x => (EnumDataAttribute)x).Where(x => x.Key == key).ToList();

            if (enumData == null || enumData.Count == 0) {
                throw new KeyNotFoundException($"Key {key} was not found!");
            } else if (enumData.Count > 1) {
                throw new NotSupportedException("There cannot be multiple values for one key!");
            }

            return enumData.First().Value;
        }

        public static TEnum GetKey<TEnum>(string key, object value) where TEnum : Enum {
            if (value == null)
                throw new ArgumentNullException("value");

            Type type = typeof(TEnum);

            var fieldTypes = type.GetFields();
            foreach (var field in fieldTypes) {
                var attributes = field.GetCustomAttributes(typeof(EnumDataAttribute), false).Select(x => (EnumDataAttribute)x);
                foreach (var attribute in attributes) {
                    if(attribute.Key == key && Equals(attribute.Value, value)) {
                        var enumInstance = (TEnum)Activator.CreateInstance(type);
                        return (TEnum)field.GetValue(enumInstance);
                    }
                }
            }

            throw new NotFoundException("value");
        }
    }
}
