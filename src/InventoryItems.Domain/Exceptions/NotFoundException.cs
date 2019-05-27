using System;

namespace InventoryItems.Domain.Exceptions {

    [Serializable]
    public class NotFoundException : Exception {
        public NotFoundException() { }
        public NotFoundException(string prop) : base($"{prop} was not found!") { }
        public NotFoundException(string message, Exception inner) : base(message, inner) { }
        protected NotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
