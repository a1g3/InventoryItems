using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryItems.ViewModels {
    public class CoinViewModel {
        public string Id { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
    }
}
