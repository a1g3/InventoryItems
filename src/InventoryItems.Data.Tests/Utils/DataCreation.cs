using InventoryItems.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace InventoryItems.Data.Tests.Utils {
    public static class DataCreation {
        public static InventoryContext CreateDb(string dbName) {
            var options = new DbContextOptionsBuilder<InventoryContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new InventoryContext(options);
        }
        public static List<Collections> CreateCollections() {
            return new List<Collections>() {
                new Collections(){ Id = Guid.NewGuid(), Name = "Collection 1" },
                new Collections(){ Id = Guid.NewGuid(), Name = "Collection 2" },
                new Collections(){ Id = Guid.NewGuid(), Name = "Collection 3" }
            };
        }
    }
}
