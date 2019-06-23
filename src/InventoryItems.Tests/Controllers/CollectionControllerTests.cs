using InventoryItems.Controllers;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Tests.Utils;
using InventoryItems.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace InventoryItems.Tests.Controllers
{
    [TestClass]
    public class CollectionControllerTests {
        [TestMethod]
        public void CollectionController_Get_Basic() {
            //ARRANGE
            var collectionId = Guid.NewGuid();
            var controller = MockUtils.MockProperties<CollectionsController>();
            var collectionViewModel = new CollectionViewModel() { Id = collectionId, Name = "Collection 543" };
            Mock.Get(controller.CollectionFacade).Setup(x => x.GetById(collectionId)).Returns(
                new CollectionDto() { Id = collectionId, Name = collectionViewModel.Name }
            );
            Mock.Get(controller.Mapper).Setup(x => x.Map<CollectionViewModel>(It.Is<CollectionDto>(p => p is CollectionDto && p.Id == collectionId && p.Name == "Collection 543"))).Returns(collectionViewModel);

            //ACT
            var collection = controller.Get(collectionId).Value as CollectionViewModel;

            //ASSERT
            Assert.AreEqual(collectionId, collection.Id);
            Assert.AreEqual("Collection 543", collection.Name);
        }
    }
}
