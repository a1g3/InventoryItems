using InventoryItems.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InventoryItems.Controllers {
    [ApiController]
    public class CoinsController : ControllerBase
    {
        // GET: api/Coins
        [HttpPut]
        [Route("api/collections/{collectionId}/coins/createcoin")]
        public IList<CoinViewModel> CreateCoin(CoinViewModel coin, Guid collectionId)
        {
            return new List<CoinViewModel>();
        }
    }
}
