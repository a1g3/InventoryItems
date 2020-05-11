using InventoryItems.Domain.Enums;
using System;

namespace InventoryItems.Domain.Dtos
{
    public class CoinDto {
        public Guid Id { get; set; }
        public string FriendlyId { get; set; }
        public string Country { get; set; }
        public CoinType Type { get; set; }
        public int Year { get; set; }
        public string Mint { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
