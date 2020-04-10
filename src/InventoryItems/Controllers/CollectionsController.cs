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
        public ICollectionFacade CollectionFacade { get; set; }
        public IMapper Mapper { get; set; }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<CollectionViewModel> GetCollectionList() {
            return new List<CollectionViewModel>() { 
                new CollectionViewModel() { Id = Guid.NewGuid(), Name = "Collection 1" },
                new CollectionViewModel() { Id = Guid.NewGuid(), Name = "Collection 2" },
                new CollectionViewModel() { Id = Guid.NewGuid(), Name = "Collection 3" }
            };
            //var viewModel = CollectionFacade.GetAll().Select(Mapper.Map<CollectionViewModel>);
            //return viewModel;
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