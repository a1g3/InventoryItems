using InventoryItems.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Interfaces.Repositories {
    public interface ICollectionRepository {
        bool DoesCollectionExist(string name);
        CollectionDto GetById(Guid collectionId);
        IList<CollectionDto> GetAll();
    }
}
