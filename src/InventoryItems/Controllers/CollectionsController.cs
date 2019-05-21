using AutoMapper;
using InventoryItems.Domain.Exceptions;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace InventoryItems.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        public ICollectionFacade CollectionFacade { get; set; }

        [HttpGet]
        [Route("[action]")]
        public JsonResult GetCollectionList() {
            var viewModel = new List<CollectionViewModel>() {
                new CollectionViewModel(){ Name = "Collection 1", Id = Guid.NewGuid() },
                new CollectionViewModel(){ Name = "Collection 2", Id = Guid.NewGuid() }
            };
            return new JsonResult(viewModel);
        }

        [HttpGet]
        public JsonResult Get(Guid collectionId) {
            var collection = CollectionFacade.GetById(collectionId);
            return new JsonResult(Mapper.Map<CollectionViewModel>(collection));
        }

        [HttpPut]
        public HttpResponseMessage Create(string name) {
            try {
                CollectionFacade.CreateCollection(name);
                return new HttpResponseMessage(HttpStatusCode.Created);
            } catch (NameAlreadyExistsException) {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public HttpResponseMessage CreateCoin(CoinViewModel coin) {
            string documentContents;
            using (Stream receiveStream = this.Request.Body) {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8)) {
                    documentContents = readStream.ReadToEnd();
                }
            }
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}