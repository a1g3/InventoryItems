using AutoMapper;
using InventoryItems.Data.Infastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryItems.Data.Tests {
    [TestClass]
    public class TestBase {

        [AssemblyInitialize]
        public static void TestAssemblyInit(TestContext testContext) {
            Mapper.Initialize(config => {
                config.AddProfile<DataMapperProfile>();
            });
        }
    }
}
