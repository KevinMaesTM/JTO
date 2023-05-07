using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public interface IRepository<T>
        where T : class, new()
    {
        void Create(T entity);

        void Delete(T entity);

        IEnumerable<T> Retrieve();
        IEnumerable<T> Retrieve(Expression<Func<T, bool>> voorwaarden);

        IEnumerable<T> Retrieve(params Expression<Func<T, object>>[] includes);

        IEnumerable<T> Retrieve(Expression<Func<T, bool>> voorwaarden,
            params Expression<Func<T, object>>[] includes);
        void Update(T entity);
    }
}