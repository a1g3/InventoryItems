using System;

namespace CoinCompanion.Web.Shared.ViewModels {
    public class CollectionViewModel {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }

    public class CollectionViewModelIn {
        public string Name { get; set; }
    }
}
