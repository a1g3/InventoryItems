using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryItems.Domain.Facades {
    public class CoinFacade : ICoinFacade {
        public ICoinRepository CoinRepository { get; set; }
        public IList<CoinDto> GetCoinList(Guid collectionId) => CoinRepository.GetCoins(collectionId);
    }
}
