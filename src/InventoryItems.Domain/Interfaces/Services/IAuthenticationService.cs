using InventoryItems.Domain.Dtos;

namespace InventoryItems.Domain.Interfaces.Services {
    public interface IAuthenticationService {
        User ValidateLogin(string username, string password);
        string GenerateToken(User user);
    }
}
