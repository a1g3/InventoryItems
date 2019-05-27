using AutoMapper;
using InventoryItems.Data.Entities;
using InventoryItems.Domain.EntityDtos;

namespace InventoryItems.Data.Infastructure {
    public class DataMapperProfile : Profile {
        public DataMapperProfile() {
            CreateMap<CoinEntityDto, Coins>(MemberList.Source);
            CreateMap<CollectionEntityDto, Collections>(MemberList.Source);
            CreateMap<Collections, CollectionEntityDto>(MemberList.Destination);
        }
    }
}
