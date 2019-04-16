using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryItems.Data.Entities {
    public class ItemProperties {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string Value { get; set; }

        public Items Item { get; set; }
    }
}
