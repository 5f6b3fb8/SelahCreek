namespace WildBillPnw.SelahCreek.Models
{
    public enum NetworkIncidentState
    {
        Empty = 0,

        New = 100,

        WipAwaitingCaller = 200,

        WipAwaitingVendor = 225,

        WipConfiguring = 250,

        WipInTransit = 275,

        Resolved = 300,

        Closed = 400,

        Rejected = 900
    }
}