namespace InventoryItems.Domain.Interfaces.Services {
    public interface IProjectService {
        void CreateProject(string name);
        bool DoesProjectExist(string name);
    }
}
