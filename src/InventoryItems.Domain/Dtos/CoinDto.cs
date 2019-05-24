using System;

namespace InventoryItems.Domain.Dtos {
    public class CoinDto {
        public Guid Id { get; set; }
        public short Country { get; set; }
        public short Type { get; set; }
        public short Year { get; set; }
        public short Mint { get; set; }
        public short Condition { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
