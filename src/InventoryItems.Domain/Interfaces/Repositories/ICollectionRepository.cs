using InventoryItems.Domain.Dtos;
using System;

namespace InventoryItems.Domain.Interfaces.Repositories {
    public interface ICollectionRepository {
        bool DoesCollectionExist(string name);
        CollectionDto GetById(Guid collectionId);
    }
}
