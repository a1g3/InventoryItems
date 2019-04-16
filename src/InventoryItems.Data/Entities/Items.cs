using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryItems.Data.Entities {
    public class Items {
        [Key]
        public Guid Id { get; set; }

        public Projects Project { get; set; }
        public ICollection<ItemProperties> Properties { get; set; }
    }
}
