using InventoryItems.Domain.Dtos;

namespace InventoryItems.Domain.Interfaces.Repositories {
    public interface IUserRepository {
        User GetUser(string username);
    }
}
