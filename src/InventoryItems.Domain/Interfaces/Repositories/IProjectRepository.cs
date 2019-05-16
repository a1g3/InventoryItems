using InventoryItems.Domain.Dtos;
using System;

namespace InventoryItems.Domain.Interfaces.Repositories {
    public interface IProjectRepository {
        ProjectDto GetById(Guid projectId);
    }
}
