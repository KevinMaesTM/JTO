using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_WPF.ViewModels
{
    internal class CourseViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public IEnumerable<Course> Courses { get; set; }
        public DashboardViewModel DVM { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public Course SelectedCourse { get; set; }

        public CourseViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Courses = unit.CourseRepo.Retrieve();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        { }
    }
}