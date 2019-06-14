using InventoryItems.Domain.EntityDtos;
using System;

namespace InventoryItems.Domain.Interfaces.Commands {
    public interface ICoinCommand {
        void CreateCoin(Guid collectionId, CoinEntityDto coinEntityDto);
        void UpdateCoin(Guid collectionId, CoinEntityDto coinEntityDto);
        void DeleteCoin(Guid coinId);
    }
}
