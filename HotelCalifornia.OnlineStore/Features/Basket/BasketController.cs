using System;
using System.Collections.Generic;
using System.Linq;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Basket;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Thingy;
using Microsoft.AspNetCore.Mvc;

namespace HotelCalifornia.OnlineStore.Features.Basket
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IThingyRepository _thingyRepository;

        public BasketController(IBasketService basketService, IThingyRepository thingyRepository)
        {
            this._basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            this._thingyRepository = thingyRepository ?? throw new ArgumentNullException(nameof(thingyRepository));
        }

        [HttpGet]
        [Route("~/basket")]
        public IActionResult Basket()
        {
            var itemsInBasket = this._basketService.Items.ToList();
            var basketDisplay = new List<BasketLineItem>();
            foreach (var itemInBasket in itemsInBasket)
            {
                var thingy = this._thingyRepository.GetOne(itemInBasket.ThingyId);
                basketDisplay.Add(new BasketLineItem(itemInBasket.Id, thingy));
            }

            var viewModel = new BasketViewModel(basketDisplay.AsReadOnly());
            return this.View(viewModel);
        }

        public IActionResult AddToBasket(BasketRequest basketRequest)
        {
            this._basketService.AddItem(basketRequest.ThingyId);
            return this.RedirectToAction("Basket");
        }

        public IActionResult RemoveFromBasket(BasketRequest basketRequest)
        {
            this._basketService.RemoveItem(basketRequest.ThingyId);
            return this.RedirectToAction("Basket");
        }

        public IActionResult EmptyBasket()
        {
            this._basketService.Empty();
            return this.RedirectToAction("Basket");
        }
    }
}