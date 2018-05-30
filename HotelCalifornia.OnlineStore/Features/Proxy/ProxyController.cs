using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelCalifornia.OnlineStore.Features.Proxy
{
    public class ProxyController : Controller
    {
        public IActionResult PspGateway(decimal value, string paymentRef, string returnUrl)
        {

            
            var uri = new UriBuilder(new Uri(returnUrl));
            if (value < 20)
            {

                if (string.IsNullOrEmpty(uri.Query))
                {
                    uri.Query = $"PaymentRef={paymentRef}&GatewayRef={Guid.NewGuid()}&IsSuccessful=True";
                }
                else
                {
                    uri.Query = $"&PaymentRef={paymentRef}&GatewayRef={Guid.NewGuid()}&IsSuccessful=True";
                }

            }
            else
            {
                if (string.IsNullOrEmpty(uri.Query))
                {
                    uri.Query = $"PaymentRef={paymentRef}&GatewayRef={Guid.NewGuid()}&IsSuccessful=False";
                }
                else
                {
                    uri.Query = $"&PaymentRef={paymentRef}&GatewayRef={Guid.NewGuid()}&IsSuccessful=False";
                }
            }

            return this.Redirect(uri.ToString());
        }


    }
}
