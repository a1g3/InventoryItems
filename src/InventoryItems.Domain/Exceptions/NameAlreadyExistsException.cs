using System;

namespace InventoryItems.Domain.Exceptions {

    [Serializable]
    public class NameAlreadyExistsException : Exception {
        public NameAlreadyExistsException() { }
        public NameAlreadyExistsException(string message) : base(message) { }
        public NameAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
        protected NameAlreadyExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
