using System.Collections.Generic;

namespace HotelCalifornia.OnlineStore.Features.Hidden
{
    public class PspSenderModel
    {
        public PspSenderModel(string gatewayUrl, IReadOnlyDictionary<string, string> formData)
        {
            this.GatewayUrl = gatewayUrl;
            this.FormData = formData;
        }
        public string GatewayUrl { get; set; }
        public IReadOnlyDictionary<string, string> FormData { get; }
    }
}