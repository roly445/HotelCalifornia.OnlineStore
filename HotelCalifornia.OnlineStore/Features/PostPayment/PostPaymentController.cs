using HotelCalifornia.OnlineStore.Infrastructure.DataProcessors;
using Microsoft.AspNetCore.Mvc;

namespace HotelCalifornia.OnlineStore.Features.PostPayment
{
    public class PostPaymentController : Controller
    {
        public PostPaymentController(IPspProcessor pspProcessor)
        {
        }


        [HttpGet]
        [Route("payment-successful")]
        public IActionResult PaymentSuccessful()
        {
            return this.View();
        }

        [HttpGet]
        [Route("payment-failed")]
        public IActionResult PaymentRejected()
        {
            return this.View();
        }
    }
}