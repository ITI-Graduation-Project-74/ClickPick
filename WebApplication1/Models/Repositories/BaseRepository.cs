using Ecommerce.Data;
using System.Linq.Expressions;

namespace Ecommerce.Models.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
           context.Set<T>().Add(entity);
           context.SaveChanges();
           return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            context.Set<T>().Remove(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
           return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
           return context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await context.Set<T>().FindAsync(id);
            return result;
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
