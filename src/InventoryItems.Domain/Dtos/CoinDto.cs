using System;
using System.Collections.Generic;

namespace InventoryItems.Domain.Dtos {
    public class CoinDto {
        public Guid Id { get; set; }
        public string FriendlyId { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public short Year { get; set; }
        public string Mint { get; set; }
        public string Condition { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
