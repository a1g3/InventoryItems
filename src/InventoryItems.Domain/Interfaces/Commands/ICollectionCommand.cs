using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.EntityDtos;

namespace InventoryItems.Domain.Interfaces.Commands {
    public interface ICollectionCommand {
        void CreateCollection(CollectionEntityDto collectionDto);
    }
}
