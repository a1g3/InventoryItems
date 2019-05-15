using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryItems.Tests {
    [TestClass]
    public class TestBase {

        [AssemblyInitialize]
        public static void TestAssemblyInit(TestContext testContext) {
            Mapper.Initialize(config => {});
        }
    }
}
