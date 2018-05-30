using System;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HotelCalifornia.OnlineStore.Infrastructure.DataProcessors;
using HotelCalifornia.OnlineStore.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HotelCalifornia.OnlineStore.Features.Hidden
{
    public class HiddenController : Controller
    {
        private readonly IPspProcessor _pspProcessor;

        public HiddenController(IPspProcessor pspProcessor)
        {
            this._pspProcessor = pspProcessor;
        }

        [HttpGet]
        [Route("~/hidden/psp-callback")]
        public IActionResult PspCallback(bool isSuccessful, string paymentRef, string gatewayRef)
        {
            var result = this._pspProcessor.ProcessResponse(new
            {
                IsSuccessful = isSuccessful,
                PaymentRef = paymentRef,
                GatewayRef = gatewayRef
            });
            if (result.IsSuccess)
            {
                this.TempData["orderRef"] = result.Value;
                return this.RedirectToAction("PaymentSuccessful", "PostPayment");
            }

            return this.RedirectToAction("PaymentRejected", "PostPayment");
        }

        [HttpPost]
        [Route("~/hidden/psp-sender")]
        public IActionResult PspSender()
        {
            var data =  this._pspProcessor.PrepData(Url.AbsoluteAction("PspCallback", "Hidden"));
            var model = new PspSenderModel(Url.AbsoluteAction("PspGateway", "Proxy"), data.ToImmutableDictionary());
            return this.View(model);
        }
    }
}
