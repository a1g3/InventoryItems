using InventoryItems.Domain.Dtos;
using System;

namespace InventoryItems.Domain.Interfaces.Facades {
    public interface IProjectFacade {
        ProjectDto GetById(Guid projectId);
    }
}
