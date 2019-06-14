using InventoryItems.Domain.Dtos;
using System.Collections.Generic;

namespace InventoryItems.Domain.Interfaces.Services {
    public interface ICollectionService {
        void CreateCollection(string name);
        bool DoesCollectionExist(string name);
    }
}
