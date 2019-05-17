using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Data.Infastructure;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.Enums;
using InventoryItems.Domain.Interfaces.Commands;
using InventoryItems.Domain.Interfaces.Infastructure;

namespace InventoryItems.Data.Commands {
    public class ProjectCommand : IProjectCommand {
        public IUnitOfWorkFactory UnitOfWorkFactory { get; set; }

        public void CreateProject(ProjectDto projectDto) {
            var projectEntity = Mapper.Map<Projects>(projectDto);
            using (var unitOfWork = UnitOfWorkFactory.GetUnitOfWork())
                unitOfWork.Queue(new EntityCommand<Projects>(CommandType.CREATE, projectEntity));
        }
    }
}
