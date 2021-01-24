using AutoMapper;
using WildBillPnw.SelahCreek.Models;

namespace WildBillPnw.SelahCreek.Profiles
{
    public class IncidentHoldReasonResolver: IValueResolver<NetworkIncident, Incident, IncidentHoldReason>
    {
        public IncidentHoldReason Resolve(NetworkIncident source, Incident destination, 
            IncidentHoldReason destMember, ResolutionContext context)
        {
            switch(source.State)
            {
                // CALLER
                case NetworkIncidentState.WipAwaitingCaller:
                    return IncidentHoldReason.AwaitingCaller;
                
                // VENDOR
                case NetworkIncidentState.WipAwaitingVendor:
                    return IncidentHoldReason.AwaitingVendor;

                default:
                    return IncidentHoldReason.Empty;
            }
        }
    }
}