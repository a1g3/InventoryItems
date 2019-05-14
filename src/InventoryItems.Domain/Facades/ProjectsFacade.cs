using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Facades;
using InventoryItems.Domain.Interfaces.Repositories;
using System;

namespace InventoryItems.Domain.Facades {
    public class ProjectsFacade : IProjectFacade {
        public IProjectRepository ProjectsRepsoitory { get; set; }

        public ProjectDto GetById(Guid projectId) => ProjectsRepsoitory.GetById(projectId);
    }
}
