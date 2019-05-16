using NsBlog.Data.Abstract;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NsBlog.Data.Concrete
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected NsBlogContext context { get; set; }

        public BaseRepository(NsBlogContext context)
        {
            this.context = context;
        }


        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>()
            .Where(expression);
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
    }
}