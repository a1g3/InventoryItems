﻿using System;

namespace InventoryItems.ViewModels {
    public class CollectionViewModel {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }

    public class CollectionViewModelIn {
        public string Name { get; set; }
    }
}
