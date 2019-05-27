using InventoryItems.Domain.Exceptions;
using InventoryItems.Domain.Infastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Tests.Infastructure {
    [TestClass]
    public class EnumHelperTests {
        [TestMethod]
        public void EnumHelper_GetValue_OneKey() {
            // Arrange
            var enumValue = TestEnum.Value1;

            // Act
            var value = enumValue.GetValue("Key");

            // Assert
            Assert.IsNotNull(value);
            Assert.AreEqual(3, (int)value);
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void EnumHelper_GetValue_NoKey() {
            // Arrange
            var enumValue = TestEnum.Value2;

            // Act
            enumValue.GetValue("Key");
        }

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void EnumHelper_GetValue_MultipleKeys() {
            // Arrange
            var enumValue = TestEnum.Value3;

            // Act
            enumValue.GetValue("Key");
        }

        [TestMethod]
        public void EnumHelper_GetKey_Basic() {
            // Act
            var enumValue = EnumHelper.GetKey<TestEnum>("Key", 3);

            // Assert
            Assert.AreEqual(TestEnum.Value1, enumValue);
        }

        [TestMethod, ExpectedException(typeof(NotFoundException))]
        public void EnumHelper_GetKey_NotFound() {
            // Act
            EnumHelper.GetKey<TestEnum>("Key", 5);
        }
    }
}

internal enum TestEnum {
    [EnumData(Key = "Key", Value = 3)]
    Value1,
    Value2,
    [EnumData(Key = "Key", Value = 8)]
    [EnumData(Key = "Key", Value = 7)]
    Value3,
}
