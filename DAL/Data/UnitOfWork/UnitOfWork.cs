using JTO_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<User> _userRepo;
        public JTOContext Context { get; }

        public IRepository<User> UserRepo
        {
            get
            {
                if (_userRepo == null)
                    _userRepo = new Repository<User>(Context);
                return _userRepo;
            }
        }

        public UnitOfWork(JTOContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}