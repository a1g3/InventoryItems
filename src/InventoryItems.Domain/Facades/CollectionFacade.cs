using AutoMapper;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Exceptions;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.Domain.Interfaces.Repositories;
using InventoryItems.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryItems.Domain.Facades {
    public class CollectionFacade : ICollectionFacade {
        public ICollectionRepository CollectionRepsoitory { get; set; }
        public ICollectionService CollectionService { get; set; }
        public IMapper Mapper { get; set; }

        public void CreateCollection(string collectionName) {
            if (!(string.IsNullOrEmpty(collectionName) || CollectionService.DoesCollectionExist(collectionName)))
                CollectionService.CreateCollection(collectionName);
            else
                throw new NameAlreadyExistsException();
        }

        public CollectionDto GetById(Guid collectionId) => Mapper.Map<CollectionDto>(CollectionRepsoitory.GetById(collectionId));
        public IList<CollectionDto> GetAll() => CollectionRepsoitory.GetAll().Select(Mapper.Map<CollectionDto>).ToList();
    }
}
