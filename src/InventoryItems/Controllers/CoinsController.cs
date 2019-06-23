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
    [Route("api/collections/{collectionId}/coins")]
    public class CoinsController : ControllerBase
    {
        public ICoinFacade CoinFacade { get; set; }
        public IMapper Mapper { get; set; }

        [HttpPut]
        public HttpResponseMessage Put(Guid collectionId, CoinViewModel coin)
        {
            try {
                coin.Country = "United States";
                CoinFacade.CreateCoin(collectionId, Mapper.Map<CoinDto>(coin));
                return new HttpResponseMessage(HttpStatusCode.Created);
            } catch {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPatch]
        public HttpResponseMessage Patch(Guid collectionId, CoinViewModel coin) {
            try {
                CoinFacade.UpdateCoin(collectionId, Mapper.Map<CoinDto>(coin));
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public JsonResult Get(Guid collectionId) {
            var coins = CoinFacade.GetCoinList(collectionId).Select(Mapper.Map<CoinViewModel>).ToList();
            return new JsonResult(coins);
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]Guid coinId)
        {
            try
            {
                CoinFacade.Delete(coinId);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
