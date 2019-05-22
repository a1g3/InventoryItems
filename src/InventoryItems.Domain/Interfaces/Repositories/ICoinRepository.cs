using InventoryItems.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryItems.Domain.Interfaces.Repositories {
    public interface ICoinRepository {
        IList<CoinDto> GetCoins(Guid collectionId);
    }
}
