using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using WildBillPnw.SelahCreek.Models;

namespace WildBillPnw.SelahCreek.Profiles
{
    public class NetworkIncidentProfile : Profile
    {
        public NetworkIncidentProfile()
        {
            CreateMap<NetworkIncident, Incident>()
                    .ForMember(i => i.CorrelationId, o => o.MapFrom(src => src.Number))
                    .ForMember(i => i.State, o => o.MapFrom(new IncidentStateResolver()))
                    .ForMember(i => i.HoldReason, o => o.MapFrom(new IncidentHoldReasonResolver()))
                .ReverseMap()
                    .ForMember(ni => ni.CorrelationId, o => o.MapFrom(src => src.Number))
                    .ForMember(ni => ni.State, o => o.MapFrom(new IncidentStateResolver()));

            CreateMap<NetworkIncidentPriority, IncidentPriority>()
                .ConvertUsingEnumMapping(opt =>
                    {
                        opt.MapValue(NetworkIncidentPriority.VeryLow, IncidentPriority.Low);
                        opt.MapValue(0, IncidentPriority.Low);
                    })
                .ReverseMap(opt =>
                    {
                        opt.MapValue(IncidentPriority.Low, NetworkIncidentPriority.Low);
                        opt.MapValue(0, NetworkIncidentPriority.Low);
                    });
        }
    }
}
