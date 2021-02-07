namespace WildBillPnw.SelahCreek.Queue
{
    public interface ISendQueue
    {
        void Send(string queue, string body);
    }
}