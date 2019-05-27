using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Models;
using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Interfaces.Services {
    public interface ICoinService {
        IList<CoinModel> GetCoins(Guid collectionId);
        void CreateCoin(Guid collectionId, CoinModel coinDto);
        void UpdateCoin(Guid collectionId, CoinModel coinModel);
        bool Exists(Guid collectionId, Guid id);
    }
}
