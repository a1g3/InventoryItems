using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.EntityDtos;
using InventoryItems.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryItems.Data.Repositories {
    public class CoinRepository : Repository<Coins>, ICoinRepository {
        public IMapper Mapper { get; set; }
        public CoinRepository(IDatabaseFactory factory) : base(factory) {}

        public IList<CoinEntityDto> GetCoins(Guid collectionId) {
            var coinEntities = (from coin in this.Db
                                where coin.CollectionId == collectionId
                                select coin).ToList();
            return coinEntities.Select(Mapper.Map<CoinEntityDto>).ToList();
        }

        public bool Exists(Guid collectionId, Guid coinId) {
            return (from coin in this.Db
                    where coin.CollectionId == collectionId && coin.Id == coinId
                    select coin).Any();
        }

    }
}
