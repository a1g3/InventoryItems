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
        public static List<Projects> CreateProjects() {
            return new List<Projects>() {
                new Projects(){ Id = Guid.NewGuid(), Name = "Project 1" },
                new Projects(){ Id = Guid.NewGuid(), Name = "Project 2" },
                new Projects(){ Id = Guid.NewGuid(), Name = "Project 3" }
            };
        }
    }
}
