using HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy;
using Microsoft.AspNetCore.Mvc;

namespace HotelCalifornia.OnlineStore.Features.Home
{
    public class HomeController : Controller
    {
        private readonly IThingyRepository _thingyRepository;

        public HomeController(IThingyRepository thingyRepository)
        {
            this._thingyRepository = thingyRepository;
        }

        [HttpGet]
        [Route("~/")]
        public IActionResult Home()
        {
            var viewModel = new HomeViewModel(this._thingyRepository.GetAll());
            return this.View(viewModel);
        }
    }
}