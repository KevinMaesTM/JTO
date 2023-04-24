using System;
using System.Collections.Generic;
using System.Linq;
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

        void Update(T entity);
    }
}