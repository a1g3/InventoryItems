namespace InventoryItems.Domain.Interfaces.Facades {
    public interface IAuthenticationFacade {
        string Login(string username, string passsword);
    }
}
