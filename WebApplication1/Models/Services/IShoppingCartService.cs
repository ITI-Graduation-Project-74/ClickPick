using Ecommerce.Models.Repositories;
using System.Linq.Expressions;

namespace Ecommerce.Models.Services
{
    public interface IShoppingCartService :IBaseRepository<ShoppingCart>
    {
        int IncrementCount(ShoppingCart shoppingcart, int count);
        int DecrementCount(ShoppingCart shoppingcart, int count);

        //IEnumerable<ShoppingCart> GetAllWithInclude(
        //    Expression<Func<ShoppingCart, bool>> expresion, string? includeProperties = null);

    }
}
