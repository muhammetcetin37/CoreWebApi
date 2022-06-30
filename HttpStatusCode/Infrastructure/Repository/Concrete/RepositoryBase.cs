using HttpStatusCode.Infrastructure.Contex;
using HttpStatusCode.Infrastructure.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HttpStatusCode.Infrastructure.Repository.Concrete
{
    public class RepositoryBase<T> : IBaseRepository<T> where T : class, new()
    {
        protected SqlDbContext context;

        public RepositoryBase()
        {
            context = new SqlDbContext();
        }

        public int Add(T input)
        {
            context.Set<T>().Add(input);
            return context.SaveChanges();
        }

        public int Delete(T input)
        {
            context.Set<T>().Remove(input);
            return context.SaveChanges();
        }

        public T Find(int Id)
        {

            return context.Set<T>().Find(Id);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return context.Set<T>().Where(filter).ToList();
            }
            else
            {
                return context.Set<T>().ToList();
            }
        }

        public IQueryable<T> FindAllInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            var query = context.Set<T>().Where(filter);
            return include.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
        }

        public int Update(T input)
        {
            context.Set<T>().Update(input);
            return context.SaveChanges();
        }
    }
}
