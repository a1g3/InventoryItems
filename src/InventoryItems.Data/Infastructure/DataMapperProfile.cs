using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.EntityDtos;

namespace InventoryItems.Data.Infastructure {
    public class DataMapperProfile : Profile {
        public DataMapperProfile() {
            CreateMap<CoinEntityDto, Coins>(MemberList.Source);
            CreateMap<CollectionDto, Collections>(MemberList.Source);
            CreateMap<Collections, CollectionDto>(MemberList.Destination);
        }
    }
}
