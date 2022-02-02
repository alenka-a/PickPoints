using AutoMapper;
using PickPoints.Core.Entities;
using PickPoints.Core.Models;

namespace PickPoints.Core.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();

            CreateMap<Order, OrderResponse>()
                .ForMember(x => x.PostampNumber, y => y.MapFrom(z => z.Postamp.Number));

            CreateMap<Postamp, PostampResponse>();
        }
    }
}
