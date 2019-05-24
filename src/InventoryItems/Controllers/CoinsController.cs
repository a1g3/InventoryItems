using AutoMapper;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public HttpResponseMessage CreateCoin(CoinViewModel coin, Guid collectionId)
        {
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // GET: api/Coins
        [HttpGet]
        [Route("api/collections/{collectionId}/coins/")]
        public JsonResult GetCoinList(Guid collectionId) {
            var coins = new List<CoinViewModel>() {
                new CoinViewModel() { Type = "Quarter", Id = "23", Condition = "Very Fine", Country = "United States", Year = 1990, Mint = "P" },
                new CoinViewModel() { Type = "Penny", Id = "2332", Condition = "Fine", Country = "United States", Year = 1887, Mint = "D" },
                new CoinViewModel() { Type = "Dime", Id = "323", Condition = "Fine", Country = "United States", Year = 1987, Mint = "D" },
                new CoinViewModel() { Type = "Dollar", Id = "87", Condition = "Mint Condition", Country = "United States", Year = 1984, Mint = "D" },
                new CoinViewModel() { Type = "Penny", Id = "48", Condition = "Poor", Country = "United States", Year = 1989, Mint = "D" },
            };
            //var coins = CoinFacade.GetCoinList(collectionId).Select(Mapper.Map<CoinViewModel>).ToList();
            return new JsonResult(coins);
        }
    }
}
