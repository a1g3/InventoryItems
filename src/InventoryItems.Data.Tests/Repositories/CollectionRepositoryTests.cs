using InventoryItems.Data.Infastructure;
using InventoryItems.Data.Repositories;
using InventoryItems.Data.Tests.Utils;
using InventoryItems.Domain.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InventoryItems.Data.Tests.Repositories {
    [TestClass]
    public class CollectionRepositoryTests : TestBase {
        [TestMethod]
        public void CollectionRepository_Basic() {
            using (var context = DataCreation.CreateDb("CollectionRepository_Basic")) {
                //ARRANGE
                var repo = new CollectionRepository(new DatabaseFactory(context));
                var collections = DataCreation.CreateCollections();
                context.AddRange(collections);
                context.SaveChanges();

                //ACT
                var collection = repo.GetById(collections[1].Id);

                //ASSERT
                Assert.IsInstanceOfType(collection, typeof(CollectionDto));
                Assert.AreEqual("Collection 2", collection.Name);
                Assert.AreEqual(collections[1].Id, collection.Id);
            }
        }

        [TestMethod]
        public void CollectionRepository_CollectionNotFound() {
            using (var context = DataCreation.CreateDb("CollectionRepository_CollectionNotFound")) {
                //ARRANGE
                var repo = new CollectionRepository(new DatabaseFactory(context));
                var collections = DataCreation.CreateCollections();
                context.AddRange(collections);
                context.SaveChanges();

                //ACT
                var collection = repo.GetById(Guid.NewGuid());

                //ASSERT
                Assert.IsNull(collection);
            }
        }
    }
}
