using AutoMapper;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.Domain.Interfaces.Services;
using InventoryItems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryItems.Domain.Facades {
    public class CoinFacade : ICoinFacade {
        public ICoinService CoinService { get; set; }
        public IList<CoinDto> GetCoinList(Guid collectionId) {
            return CoinService.GetCoins(collectionId).Select(Mapper.Map<CoinDto>).ToList();
        }

        public void CreateCoin(Guid collectionId, CoinDto coinDto) {
            CoinService.CreateCoin(collectionId, Mapper.Map<CoinModel>(coinDto));
        }
    }
}
