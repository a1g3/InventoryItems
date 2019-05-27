using AutoMapper;
using InventoryItems.Domain.Dtos;
using InventoryItems.ViewModels;
using System;

namespace InventoryItems.Helpers {
    public class WebMapperProfile : Profile {
        public WebMapperProfile() {
            CreateMap<CoinViewModel, CoinDto>().ConvertUsing<CoinViewModelToCoinDto>();
        }
    }

    public class CoinViewModelToCoinDto : ITypeConverter<CoinViewModel, CoinDto> {
        public CoinDto Convert(CoinViewModel source, CoinDto destination, ResolutionContext context) {
            return new CoinDto() {
                FriendlyId = source.Id,
                Condition = source.Condition,
                Country = source.Country,
                Description = source.Description,
                Mint = source.Mint,
                Type = source.Type,
                Url = source.Url,
                Year = source.Year
            };
        }
    }
}
