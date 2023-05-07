using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {
        protected JTOContext Context { get; }

        public Repository(JTOContext context)
        {
            this.Context = context;
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Retrieve()
        {
            return Context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public IEnumerable<T> Retrieve(Expression<Func<T, bool>> voorwaarden,
           params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (voorwaarden != null)
            {
                query = query.Where(voorwaarden);
            }
            return query.ToList();
        }

        public IEnumerable<T> Retrieve(Expression<Func<T, bool>> voorwaarden)
        {
            return Retrieve(voorwaarden, null).ToList();
        }

        public IEnumerable<T> Retrieve(params Expression<Func<T, object>>[] includes)
        {
            return Retrieve(null, includes).ToList();
        }

    }
}