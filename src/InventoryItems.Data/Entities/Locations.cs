using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryItems.Data.Entities {
    public class Locations {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Projects Project { get; set; }
        public Locations SubLocation { get; set; }
    }
}
