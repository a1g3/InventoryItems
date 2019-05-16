using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Domain.Dtos;

namespace InventoryItems.Data.Infastructure {
    public class DataMapperProfile : Profile {
        public DataMapperProfile() {
            CreateMap<Projects, ProjectDto>(MemberList.Destination);
        }
    }
}
