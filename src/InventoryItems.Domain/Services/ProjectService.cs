using InventoryItems.Domain.Interfaces.Commands;
using InventoryItems.Domain.Interfaces.Infastructure;
using InventoryItems.Domain.Interfaces.Repositories;
using InventoryItems.Domain.Interfaces.Services;
using System;

namespace InventoryItems.Domain.Services {
    public class ProjectService : IProjectService {
        public IProjectCommand ProjectCommand { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public void CreateProject(string name) => ProjectCommand.CreateProject(new Dtos.ProjectDto() { Id = Guid.NewGuid(), Name = name });

        public bool DoesProjectExist(string name) => ProjectRepository.DoesProjectExist(name);
    }
}
