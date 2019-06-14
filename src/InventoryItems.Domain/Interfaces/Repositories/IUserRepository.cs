using InventoryItems.Domain.EntityDtos;

namespace InventoryItems.Domain.Interfaces.Repositories {
    public interface IUserRepository {
        UserEntityDto GetUser(string username);
    }
}
