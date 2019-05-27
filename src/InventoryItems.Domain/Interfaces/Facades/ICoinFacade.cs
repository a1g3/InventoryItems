using InventoryItems.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Interfaces.Facades {
    public interface ICoinFacade {
        IList<CoinDto> GetCoinList(Guid collectionId);
        void CreateCoin(Guid collectionId, CoinDto coinDto);
    }
}
