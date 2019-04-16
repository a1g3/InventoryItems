using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryItems.Data.Entities {
    public class Projects {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Items> Items { get; set; }
        public ICollection<Locations> Locations { get; set; }
    }
}
