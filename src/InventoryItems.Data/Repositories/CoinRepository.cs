using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.EntityDtos;
using InventoryItems.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryItems.Data.Repositories {
    public class CoinRepository : Repository<Coins>, ICoinRepository {
        public CoinRepository(IDatabaseFactory factory) : base(factory) {}

        public IList<CoinEntityDto> GetCoins(Guid collectionId) {
            var coinEntities = (from coin in this.Db
                                where coin.CollectionId == collectionId
                                select coin).ToList();
            return coinEntities.Select(Mapper.Map<CoinEntityDto>).ToList();
        }
    }
}
