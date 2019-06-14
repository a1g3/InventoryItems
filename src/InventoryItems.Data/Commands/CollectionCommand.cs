using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.EntityDtos;
using InventoryItems.Domain.Enums;
using InventoryItems.Domain.Interfaces.Commands;
using InventoryItems.Domain.Interfaces.Infastructure;

namespace InventoryItems.Data.Commands {
    public class CollectionCommand : ICollectionCommand {
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public void CreateCollection(CollectionEntityDto collectionDto) {
            var collectionEntity = Mapper.Map<Collections>(collectionDto);
            using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork())
                unitOfWork.Queue(new EntityCommand<Collections>(CommandType.CREATE, collectionEntity));
        }
    }
}
