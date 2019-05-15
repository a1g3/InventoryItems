using Moq;
using System;
using System.Linq;

namespace InventoryItems.Domain.Tests.Utils {
    public sealed class MockUtils {
        public static T MockProperties<T>() where T : new() {
            var classType = typeof(T);
            var classInstance = Activator.CreateInstance(classType);
            var classProperties = classType.GetProperties().Where(x => x.CanWrite);
            var classInterfaces = classProperties.Where(x => x.PropertyType.IsInterface);

            foreach (var classInterface in classInterfaces) {
                var type = typeof(Mock<>).MakeGenericType(classInterface.PropertyType);
                Mock mockInstance = (Mock)type.GetConstructor(new Type[] { typeof(MockBehavior) }).Invoke(new object[] { MockBehavior.Strict });

                classInterface.SetValue(classInstance, mockInstance.Object);
            }

            return (T)classInstance;
        }
    }
}
