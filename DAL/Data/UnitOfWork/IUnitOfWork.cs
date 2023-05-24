using JTO_Models;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AgeCategory> AgeCategoryRepo { get; }
        IRepository<Course> CourseRepo { get; }
        IRepository<Destination> DestinationRepo { get; }
        IRepository<GroupTour> GroupTourRepo { get; }
        IRepository<Participant> ParticipantRepo { get; }
        IRepository<Person> PersonRepo { get; }
        IRepository<Role> RoleRepo { get; }
        IRepository<Theme> ThemeRepo { get; }
        IRepository<Training> TrainingRepo { get; }
        IRepository<User> UserRepo { get; }

        int Save();
    }
}