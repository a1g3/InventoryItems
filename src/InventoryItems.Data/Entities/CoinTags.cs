using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryItems.Data.Entities
{
    public class CoinTags
    {
        public Guid CoinId { get; set; }
        public Coins Coin { get; set; }
        public Guid TagId { get; set; }
        public Tags Tag { get; set; }
    }
}
