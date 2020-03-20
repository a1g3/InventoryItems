using AutoMapper;
using InventoryItems.Domain.Dtos;
using CoinCompanion.Web.Server.ViewModels;
using System;

namespace CoinCompanion.Web.Server.Helpers {
    public class WebMapperProfile : Profile {
        public WebMapperProfile() {
            CreateMap<CollectionDto, CollectionViewModel>();
            CreateMap<CoinDto, CoinViewModel>();
            CreateMap<CoinViewModel, CoinDto>().ConvertUsing<CoinViewModelToCoinDto>();
        }
    }

    public class CoinViewModelToCoinDto : ITypeConverter<CoinViewModel, CoinDto> {
        public CoinDto Convert(CoinViewModel source, CoinDto destination, ResolutionContext context) {
            return new CoinDto() {
                Id = !string.IsNullOrEmpty(source.Id) ? Guid.Parse(source.Id) : default,
                FriendlyId = source.FriendlyId,
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
