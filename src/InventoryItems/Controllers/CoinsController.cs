using AutoMapper;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace InventoryItems.Controllers {
    [ApiController]
    public class CoinsController : ControllerBase
    {
        public ICoinFacade CoinFacade { get; set; }

        [HttpPut]
        [Route("api/collections/{collectionId}/coins/createcoin")]
        public HttpResponseMessage CreateCoin(Guid collectionId, CoinViewModel coin)
        {
            coin.Mint = "Denver";
            CoinFacade.CreateCoin(collectionId, Mapper.Map<CoinDto>(coin));
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // GET: api/Coins
        [HttpGet]
        [Route("api/collections/{collectionId}/coins/")]
        public JsonResult GetCoinList(Guid collectionId) {
            var coins = CoinFacade.GetCoinList(collectionId).Select(Mapper.Map<CoinViewModel>).ToList();
            return new JsonResult(coins);
        }
    }
}
