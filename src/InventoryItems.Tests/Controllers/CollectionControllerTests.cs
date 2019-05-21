using InventoryItems.Controllers;
using InventoryItems.Domain.Tests.Utils;
using InventoryItems.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;

namespace InventoryItems.Tests.Controllers {
    [TestClass]
    public class CollectionControllerTests {
        [TestMethod]
        public void CollectionController_Get_Basic() {
            //ARRANGE
            var collectionId = Guid.NewGuid();
            var controller = MockUtils.MockProperties<CollectionsController>();
            Mock.Get(controller.CollectionFacade).Setup(x => x.GetById(collectionId)).Returns(
                new Domain.Dtos.CollectionDto() { Id = collectionId, Name = "Collection 543" }
            );

            //ACT
            var collection = controller.Get(collectionId).Value as CollectionViewModel;

            //ASSERT
            Assert.AreEqual(collectionId, collection.Id);
            Assert.AreEqual("Collection 543", collection.Name);
        }
    }
}
