using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace InventoryItems.Data.Repositories {
    public class ProjectRepository : Repository<Projects>, IProjectRepository {
        public ProjectRepository(IDatabaseFactory factory) : base(factory) {}

        public ProjectDto GetById(Guid projectId) {
            var projectEntity = (from project in this.Db
                    where project.Id == projectId
                    select project).FirstOrDefault();
            return projectEntity is null ? null : Mapper.Map<ProjectDto>(projectEntity);
        }
    }
}
