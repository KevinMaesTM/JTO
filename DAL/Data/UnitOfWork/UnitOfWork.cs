using JTO_Models;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<AgeCategory> _ageCategoryRepo;
        private IRepository<Course> _courseRepo;
        private IRepository<Destination> _destinationRepo;
        private IRepository<GroupTour> _groupTourRepo;
        private IRepository<Participant> _participantRepo;
        private IRepository<Person> _personRepo;
        private IRepository<Role> _roleRepo;
        private IRepository<Theme> _themeRepo;
        private IRepository<Training> _trainingRepo;
        private IRepository<User> _userRepo;

        public IRepository<AgeCategory> AgeCategoryRepo
        {
            get
            {
                if (_ageCategoryRepo == null)
                {
                    _ageCategoryRepo = new Repository<AgeCategory>(Context);
                }
                return _ageCategoryRepo;
            }
        }

        public IRepository<Course> CourseRepo
        {
            get
            {
                if (_courseRepo == null)
                {
                    _courseRepo = new Repository<Course>(Context);
                }
                return _courseRepo;
            }
        }

        public IRepository<Destination> DestinationRepo
        {
            get
            {
                if (_destinationRepo == null)
                {
                    _destinationRepo = new Repository<Destination>(Context);
                }
                return _destinationRepo;
            }
        }

        public IRepository<GroupTour> GroupTourRepo
        {
            get
            {
                if (_groupTourRepo == null)
                {
                    _groupTourRepo = new Repository<GroupTour>(Context);
                }
                return _groupTourRepo;
            }
        }

        public IRepository<Participant> ParticipantRepo
        {
            get
            {
                if (_participantRepo == null)
                {
                    _participantRepo = new Repository<Participant>(Context);
                }
                return _participantRepo;
            }
        }

        public IRepository<Person> PersonRepo
        {
            get
            {
                if (_personRepo == null)
                {
                    _personRepo = new Repository<Person>(Context);
                }
                return _personRepo;
            }
        }

        public IRepository<Role> RoleRepo
        {
            get
            {
                if (_roleRepo == null)
                {
                    _roleRepo = new Repository<Role>(Context);
                }
                return _roleRepo;
            }
        }

        public IRepository<Theme> ThemeRepo
        {
            get
            {
                if (_themeRepo == null)
                {
                    _themeRepo = new Repository<Theme>(Context);
                }
                return _themeRepo;
            }
        }

        public IRepository<Training> TrainingRepo
        {
            get
            {
                if (_trainingRepo == null)
                {
                    _trainingRepo = new Repository<Training>(Context);
                }
                return _trainingRepo;
            }
        }

        public IRepository<User> UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new Repository<User>(Context);
                }
                return _userRepo;
            }
        }

        private JTOContext Context { get; }

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