using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.EntityDtos;

namespace InventoryItems.Domain.Interfaces.Services {
    public interface IAuthenticationService {
        UserEntityDto ValidateLogin(string username, string password);
        string GenerateToken(UserEntityDto user);
    }
}
