using AutoMapper;
using CoinCompanion.Web.Shared.ViewModels;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CoinCompanion.Web.Server.Controllers
{
    [ApiController]
    [Route("api/collections/{collectionId}/coins")]
    public class CoinsController : ControllerBase
    {
        public ICoinFacade CoinFacade { get; private set; }
        public IMapper Mapper { get; private set; }

        public CoinsController(ICoinFacade coinFacade, IMapper mapper)
        {
            this.Mapper = mapper;
            this.CoinFacade = coinFacade;
        }

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
