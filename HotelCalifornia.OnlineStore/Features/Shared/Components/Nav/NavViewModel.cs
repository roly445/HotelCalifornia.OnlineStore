namespace HotelCalifornia.OnlineStore.Features.Shared.Components.Nav
{
    public class NavViewModel
    {
        public NavViewModel(int basketItemCount)
        {
            this.BasketItemCount = basketItemCount;
        }

        public readonly int BasketItemCount;
    }
}