using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryItems.Data.Entities {
    public class Collections {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Coins> Coins { get; set; }
    }
}
