using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClickPick.Data.ViewComponents
{
    public class CartItemsCount : ViewComponent
    {
        private readonly ShoppingCart _ShoppingCartcount;

        public CartItemsCount(ShoppingCart ShoppingCartcount)
        {
            _ShoppingCartcount = ShoppingCartcount;
        }

        public IViewComponentResult Invoke()
        {
            var items = _ShoppingCartcount.Count;
            return View(items);
        }
    }

}
