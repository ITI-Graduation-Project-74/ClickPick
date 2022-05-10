using System.Linq.Expressions;

namespace Ecommerce.Models.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);
        T Find(Expression<Func<T, bool>> expression);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllEagerLodingAsync(Expression<Func<T, bool>> expression, string[] includes = null);

        Task<T> GetEagerLodingAsync(Expression<Func<T, bool>> expression, string[] includes = null);


}
}
