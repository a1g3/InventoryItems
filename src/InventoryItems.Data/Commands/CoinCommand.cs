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
        public IMapper Mapper { get; set; }
        public InventoryContext Context { get; set; }

        public void CreateCoin(Guid collectionId, CoinEntityDto coinEntityDto) {
            var coinEntity = Mapper.Map<Coins>(coinEntityDto);
            coinEntity.Id = Guid.NewGuid();
            coinEntity.CollectionId = collectionId;
            using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork())
                unitOfWork.Queue(new EntityCommand<Coins>(CommandType.CREATE, coinEntity));
        }

        public void UpdateCoin(Guid collectionId, CoinEntityDto coinEntityDto) {
            var coinEntity = Mapper.Map<Coins>(coinEntityDto);
            coinEntity.CollectionId = collectionId;
            using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork())
                unitOfWork.Queue(new EntityCommand<Coins>(CommandType.UPDATE, coinEntity));
        }

        public void DeleteCoin(Guid coinId)
        {
            var coinEntity = Context.Find(typeof(Coins), coinId) as Coins;
            using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork())
                unitOfWork.Queue(new EntityCommand<Coins>(CommandType.DELETE, coinEntity));
        }
    }
}
