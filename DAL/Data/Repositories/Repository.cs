using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}