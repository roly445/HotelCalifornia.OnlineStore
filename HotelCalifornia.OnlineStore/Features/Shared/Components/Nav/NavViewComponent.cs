using System;
using HotelCalifornia.OnlineStore.Infrastructure.Data.Basket;
using Microsoft.AspNetCore.Mvc;

namespace HotelCalifornia.OnlineStore.Features.Shared.Components.Nav
{
    public class NavViewComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public NavViewComponent(IBasketService basketService)
        {
            this._basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public IViewComponentResult Invoke()
        {
            var model = new NavViewModel(this._basketService.Items.Count);
            return this.View(model);
        }
    }
}