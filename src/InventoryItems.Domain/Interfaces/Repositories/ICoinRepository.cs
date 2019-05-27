using InventoryItems.Domain.EntityDtos;
using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Interfaces.Repositories {
    public interface ICoinRepository {
        IList<CoinEntityDto> GetCoins(Guid collectionId);
    }
}
