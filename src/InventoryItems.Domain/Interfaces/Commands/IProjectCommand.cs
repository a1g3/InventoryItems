using InventoryItems.Domain.Dtos;

namespace InventoryItems.Domain.Interfaces.Commands {
    public interface IProjectCommand {
        void CreateProject(ProjectDto projectDto);
    }
}
