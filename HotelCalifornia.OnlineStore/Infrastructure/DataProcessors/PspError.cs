namespace HotelCalifornia.OnlineStore.Infrastructure.DataProcessors
{
    public class PspError
    {
        public PspError(string reason, int code)
        {
            this.Reason = reason;
            this.Code = code;
        }

        public string Reason { get; }
        public int Code { get; }
    }
}