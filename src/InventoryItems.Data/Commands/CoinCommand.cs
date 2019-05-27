using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.EntityDtos;
using InventoryItems.Domain.Enums;
using InventoryItems.Domain.Interfaces.Commands;
using InventoryItems.Domain.Interfaces.Infastructure;
using System;

namespace InventoryItems.Data.Commands {
    public class CoinCommand : ICoinCommand {
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }
        public void CreateCoin(Guid collectionId, CoinEntityDto coinEntityDto) {
            var coinEntity = Mapper.Map<Coins>(coinEntityDto);
            coinEntity.Id = Guid.NewGuid();
            coinEntity.CollectionId = collectionId;
            using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork())
                unitOfWork.Queue(new EntityCommand<Coins>(CommandType.CREATE, coinEntity));
        }
    }
}
