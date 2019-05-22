using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryItems.Data.Repositories {
    public class CollectionRepository : Repository<Collections>, ICollectionRepository {
        public CollectionRepository(IDatabaseFactory factory) : base(factory) {}

        public IList<CollectionDto> GetAll() {
            var collections = (from collection in this.Db
                               select collection).ToList();
            return collections.Count == 0 ? null : collections.Select(Mapper.Map<CollectionDto>).ToList();
        }

        public bool DoesCollectionExist(string name) {
            return (from collection in this.Db
                    where string.Equals(collection.Name, name, StringComparison.Ordinal)
                    select collection).Any();
        }

        public CollectionDto GetById(Guid collectionId) {
            var collectionEntity = (from collection in this.Db
                    where collection.Id == collectionId
                    select collection).FirstOrDefault();
            return collectionEntity is null ? null : Mapper.Map<CollectionDto>(collectionEntity);
        }
    }
}
