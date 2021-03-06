using Ecommerce.Data;
using Ecommerce.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Models.Services
{
    public class ShoppingCartService : BaseRepository<ShoppingCart>,IShoppingCartService
    {
        private readonly AppDbContext _context;

        public ShoppingCartService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int DecrementCount(ShoppingCart shoppingcart, int count)
        {
            shoppingcart.Count -= count;
            return shoppingcart.Count;
        }
        public int IncrementCount(ShoppingCart shoppingcart, int count)
        {
            shoppingcart.Count += count;

            return shoppingcart.Count;
        }


    }
}
