using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryItems.Data.Entities
{
    public class Tags
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Text { get; set; }

        public ICollection<Coins> Coins { get; set; }
    }
}
