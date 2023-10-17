using AutoMapper;
using LuminosECommerce.Models;
using LuminosECommerce.Models.DTOs;

namespace LuminosECommerce.UI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderRequestDTO, Order>()
                .ForMember(
                    dest => dest.Total,
                    opt => opt.MapFrom(src => src.Total)
                )
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId)
                )
                .ForMember(
                    dest => dest.OrderDate,
                    opt => opt.MapFrom(src => src.OrderDate)
                );
        }
    }
}
