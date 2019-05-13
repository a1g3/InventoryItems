using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.Domain.Interfaces.Services;

namespace InventoryItems.Domain.Facades {
    public class AuthenticationFacade : IAuthenticationFacade {
        public IAuthenticationService AuthenticationService { get; set; }
        public string Login(string username, string passsword) {
            var user = AuthenticationService.ValidateLogin(username, passsword);
            if (user == null) return string.Empty;
            return AuthenticationService.GenerateToken(user);
        }
    }
}
