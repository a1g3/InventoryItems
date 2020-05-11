using AutoMapper;
using CoinCompanion.Web.Shared.ViewModels;
using InventoryItems.Domain.Exceptions;
using InventoryItems.Domain.Interfaces.Facades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CoinCompanion.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        public ICollectionFacade CollectionFacade { get; private set; }
        public IMapper Mapper { get; private set; }

        public CollectionsController(ICollectionFacade collectionFacade, IMapper mapper)
        {
            this.CollectionFacade = collectionFacade;
            this.Mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<CollectionViewModel> GetCollectionList() {
            var viewModel = CollectionFacade.GetAll().Select(Mapper.Map<CollectionViewModel>);
            return viewModel;
        }

        [HttpGet]
        public JsonResult Get(Guid collectionId) {
            var collection = CollectionFacade.GetById(collectionId);
            return new JsonResult(Mapper.Map<CollectionViewModel>(collection));
        }

        [HttpPut]
        [Route("[action]")]
        public HttpResponseMessage Create(CollectionViewModelIn collection) {
            try {
                CollectionFacade.CreateCollection(collection.Name);
                return new HttpResponseMessage(HttpStatusCode.Created);
            } catch (NameAlreadyExistsException) {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
        }
    }
}