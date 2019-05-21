using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryItems.Data.Entities {
    public class Coins {
        [Key]
        public Guid Id { get; set; }
        public int Country { get; set; }
        public int Year { get; set; }
        public int Mint { get; set; }
        public int Condition { get; set; }
        public string Description { get; set; }
    }
}
