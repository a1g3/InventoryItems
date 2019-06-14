using InventoryItems.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Interfaces.Facades {
    public interface ICollectionFacade {
        CollectionDto GetById(Guid collectionId);
        void CreateCollection(string collectionName);
        IList<CollectionDto> GetAll();
    }
}
