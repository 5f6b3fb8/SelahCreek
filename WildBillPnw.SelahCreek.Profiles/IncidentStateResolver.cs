using AutoMapper;
using WildBillPnw.SelahCreek.Models;

namespace WildBillPnw.SelahCreek.Profiles
{
    public class IncidentStateResolver
        : IValueResolver<NetworkIncident, Incident, IncidentState>
        , IValueResolver<Incident, NetworkIncident, NetworkIncidentState>
    {
        public IncidentState Resolve(NetworkIncident source, Incident destination, 
            IncidentState stateCode, ResolutionContext context)
        {
            switch (source.State)
            {
                // ONHOLD
                case NetworkIncidentState.WipAwaitingCaller:
                case NetworkIncidentState.WipAwaitingVendor:
                    return IncidentState.OnHold;

                // IN PROGRESS
                case NetworkIncidentState.WipConfiguring:
                case NetworkIncidentState.WipInTransit:
                    return IncidentState.InProgress;

                // RESOLVED
                case NetworkIncidentState.Resolved:
                    return IncidentState.Resolved;

                // CANCELED
                case NetworkIncidentState.Rejected:
                    return IncidentState.Canceled;

                // CLOSED
                case NetworkIncidentState.Closed:
                    return IncidentState.Closed;

                // NEW
                default:
                    return IncidentState.New;
            }
        }

        public NetworkIncidentState Resolve(Incident source, NetworkIncident destination,
            NetworkIncidentState destMember, ResolutionContext context)
        {
            switch (source.State)
            {
                case IncidentState.InProgress:
                    return NetworkIncidentState.WipConfiguring;
                
                case IncidentState.Canceled:
                    return NetworkIncidentState.Rejected;
                
                case IncidentState.Resolved:
                    return NetworkIncidentState.Resolved;
                
                case IncidentState.Closed:
                    return NetworkIncidentState.Closed;
            }

            switch (source.HoldReason)
            {
                case IncidentHoldReason.AwaitingCaller:
                case IncidentHoldReason.AwaitingProblem:
                case IncidentHoldReason.AwaitingChange:
                    return NetworkIncidentState.WipAwaitingCaller;

                case IncidentHoldReason.AwaitingVendor:
                    return NetworkIncidentState.WipAwaitingVendor;
            }

            return NetworkIncidentState.New;
        }
    }
}