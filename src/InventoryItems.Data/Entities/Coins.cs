using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryItems.Data.Entities {
    public class Coins {
        [Key]
        public Guid Id { get; set; }
        public int Country { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
    }
}
