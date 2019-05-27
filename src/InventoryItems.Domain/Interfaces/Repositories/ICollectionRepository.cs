using InventoryItems.Domain.EntityDtos;
using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Interfaces.Repositories {
    public interface ICollectionRepository {
        bool DoesCollectionExist(string name);
        CollectionEntityDto GetById(Guid collectionId);
        IList<CollectionEntityDto> GetAll();
    }
}
