using AutoMapper;
using InventoryItems.Data.Infastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryItems.Data.Tests {
    [TestClass]
    public class TestBase {

        public static Mapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(config => {
                config.AddMaps("InventoryItems.Data");
            });

            return new Mapper(mapperConfig);
        }
    }
}
