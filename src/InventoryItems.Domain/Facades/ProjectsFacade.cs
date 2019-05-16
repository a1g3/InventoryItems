using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.Domain.Interfaces.Repositories;
using InventoryItems.Domain.Interfaces.Services;
using System;

namespace InventoryItems.Domain.Facades {
    public class ProjectsFacade : IProjectFacade {
        public IProjectRepository ProjectsRepsoitory { get; set; }
        public IProjectService ProjectService { get; set; }

        public void CreateProject(string projectName) {
            if (!(string.IsNullOrEmpty(projectName) && ProjectService.DoesProjectExist(projectName)))
                ProjectService.CreateProject(projectName);
        }

        public ProjectDto GetById(Guid projectId) => ProjectsRepsoitory.GetById(projectId);
    }
}
