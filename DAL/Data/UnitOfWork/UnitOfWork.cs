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
        private IRepository<Country> _countryRepo;
        private IRepository<Course> _courseRepo;
        private IRepository<Destination> _destinationRepo;
        private IRepository<GroupTour> _groupTourRepo;
        private IRepository<MedicalSheet> _medicalSheetRepo;
        private IRepository<Participant> _participantRepo;
        private IRepository<Person> _personRepo;
        private IRepository<Role> _roleRepo;
        private IRepository<Theme> _themeRepo;
        private IRepository<Training> _trainingRepo;
        private IRepository<User> _userRepo;

        public IRepository<AgeCategory> AgeCategoryRepo
        {
            get { return _ageCategoryRepo; }
            set { _ageCategoryRepo = value; }
        }

        public IRepository<Country> CountryRepo
        {
            get { return _countryRepo; }
            set { _countryRepo = value; }
        }

        public IRepository<Course> CourseRepo
        {
            get { return _courseRepo; }
            set { _courseRepo = value; }
        }

        public IRepository<Destination> DestinationRepo
        {
            get { return _destinationRepo; }
            set { _destinationRepo = value; }
        }

        public IRepository<GroupTour> GroupTourRepo
        {
            get { return _groupTourRepo; }
            set { _groupTourRepo = value; }
        }

        public IRepository<MedicalSheet> MedicalSheetRepo
        {
            get { return _medicalSheetRepo; }
            set { _medicalSheetRepo = value; }
        }

        public IRepository<Participant> ParticipantRepo
        {
            get { return _participantRepo; }
            set { _participantRepo = value; }
        }

        public IRepository<Person> PersonRepo
        {
            get { return _personRepo; }
            set { _personRepo = value; }
        }

        public IRepository<Role> RoleRepo
        {
            get { return _roleRepo; }
            set { _roleRepo = value; }
        }

        public IRepository<Theme> ThemeRepo
        {
            get { return _themeRepo; }
            set { _themeRepo = value; }
        }

        public IRepository<Training> TrainingRepo
        {
            get { return _trainingRepo; }
            set { _trainingRepo = value; }
        }

        public IRepository<User> UserRepo
        {
            get { return _userRepo; }
            set { _userRepo = value; }
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