using InventoryItems.Domain.Dtos;
using System;

namespace InventoryItems.Domain.Interfaces.Facades {
    public interface ICollectionFacade {
        CollectionDto GetById(Guid collectionId);
        void CreateCollection(string collectionName);
    }
}
