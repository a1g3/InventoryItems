using AutoMapper;
using InventoryItems.Domain.EntityDtos;
using InventoryItems.Domain.Interfaces.Commands;
using InventoryItems.Domain.Interfaces.Repositories;
using InventoryItems.Domain.Interfaces.Services;
using InventoryItems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryItems.Domain.Services {
    public class CoinService : ICoinService {
        public ICoinRepository CoinRepository { get; set; }
        public ICoinCommand CoinCommand { get; set; }

        public IList<CoinModel> GetCoins(Guid collectionId) => CoinRepository.GetCoins(collectionId).Select(Mapper.Map<CoinModel>).ToList();

        public void CreateCoin(Guid collectionId, CoinModel coinModel) => CoinCommand.CreateCoin(collectionId, Mapper.Map<CoinEntityDto>(coinModel));

        public void UpdateCoin(Guid collectionId, CoinModel coinModel) => CoinCommand.UpdateCoin(collectionId, Mapper.Map<CoinEntityDto>(coinModel));

        public bool Exists(Guid collectionId, Guid coinId) => CoinRepository.Exists(collectionId, coinId);

        public void Delete(Guid coinId) => CoinCommand.DeleteCoin(coinId);
    }
}
