using InventoryItems.Domain.Dtos;

namespace InventoryItems.Domain.Interfaces.Commands {
    public interface ICollectionCommand {
        void CreateCollection(CollectionDto collectionDto);
    }
}
