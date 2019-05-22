using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Commands;
using InventoryItems.Domain.Interfaces.Infastructure;
using InventoryItems.Domain.Interfaces.Repositories;
using InventoryItems.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Services {
    public class CollectionService : ICollectionService {
        public ICollectionCommand CollectionCommand { get; set; }
        public ICollectionRepository CollectionRepository { get; set; }
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public void CreateCollection(string name) => CollectionCommand.CreateCollection(new Dtos.CollectionDto() { Id = Guid.NewGuid(), Name = name });

        public bool DoesCollectionExist(string name) => CollectionRepository.DoesCollectionExist(name);
    }
}
