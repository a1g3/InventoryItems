using AutoMapper;
using InventoryItems.Domain.Exceptions;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace InventoryItems.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        public ICollectionFacade CollectionFacade { get; set; }

        [HttpGet]
        [Route("[action]")]
        public JsonResult GetCollectionList() {
            var viewModel = CollectionFacade.GetAll().Select(Mapper.Map<CollectionViewModel>);
            return new JsonResult(viewModel);
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