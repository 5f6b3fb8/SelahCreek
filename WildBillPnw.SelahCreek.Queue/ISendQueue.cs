namespace WildBillPnw.SelahCreek.Queue
{
    public interface ISendQueue
    {
        void SendQueue(string queue, string body);
    }
}