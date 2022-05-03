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

        //public IEnumerable<ShoppingCart> GetAllWithInclude(Expression<Func<ShoppingCart, bool>> expresion, string includeProperties = null)
        //{
        //    IQueryable<ShoppingCart> query = _context;
        //    query = query.Where(expresion);

        //    if(includeProperties != null)
        //    {
        //        foreach (var property in includeProperties.Split(new char[] { ',' }))
        //        {
        //            query = query.Include(property);
        //        }
        //    }
        //    return query.ToList();
        //}

        public int IncrementCount(ShoppingCart shoppingcart, int count)
        {
            shoppingcart.Count += count;

            return shoppingcart.Count;
        }


    }
}
