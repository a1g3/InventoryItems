using AutoMapper;
using InventoryItems.Domain.Dtos;
using InventoryItems.Domain.EntityDtos;
using InventoryItems.Domain.Enums;
using InventoryItems.Domain.Models;

namespace InventoryItems.Domain.Infastructure {
    public class DomainMapperProfile : Profile {
        public DomainMapperProfile() {
            CreateMap<CoinModel, CoinEntityDto>();
            CreateMap<CollectionEntityDto, CollectionDto>();
            CreateMap<CoinEntityDto, CoinModel>();
            CreateMap<CoinDto, CoinModel>().ConvertUsing<CoinDtoToCoinModel>();
            CreateMap<CoinModel, CoinDto>().ConvertUsing<CoinModelToCoinDto>();
        }
    }

    public class CoinDtoToCoinModel : ITypeConverter<CoinDto, CoinModel> {
        public CoinModel Convert(CoinDto source, CoinModel destination, ResolutionContext context) {
            return new CoinModel() {
                Id = source.Id,
                FriendlyId = source.FriendlyId,
                Country = (short)EnumHelper.GetKey<Country>(Constants.DISPLAY_NAME_KEY, source.Country),
                Type = source.Type,
                Year = source.Year,
                Mint = (short)EnumHelper.GetKey<MintType>(Constants.DISPLAY_NAME_KEY, source.Mint),
                Condition = (short)EnumHelper.GetKey<ConditionType>(Constants.DISPLAY_NAME_KEY, source.Condition),
                Description = source.Description,
                Url = source.Url
            };
        }
    }

    public class CoinModelToCoinDto : ITypeConverter<CoinModel, CoinDto> {

        public CoinDto Convert(CoinModel source, CoinDto destination, ResolutionContext context) {
            return new CoinDto() {
                Id = source.Id,
                FriendlyId = source.FriendlyId,
                Country = ((Country)source.Country).GetValue(Constants.DISPLAY_NAME_KEY).ToString(),
                Type = source.Type,
                Year = source.Year,
                Mint = ((MintType)source.Mint).GetValue(Constants.DISPLAY_NAME_KEY).ToString(),
                Condition = ((ConditionType)source.Condition).GetValue(Constants.DISPLAY_NAME_KEY).ToString(),
                Description = source.Description,
                Url = source.Url
            };
        }
    }
}
