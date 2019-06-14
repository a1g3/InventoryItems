using System;

namespace InventoryItems.Domain.EntityDtos {
    public class UserEntityDto {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
