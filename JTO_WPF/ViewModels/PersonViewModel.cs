using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_WPF.ViewModels
{
    internal class PersonViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public GroupTour SelectedPerson { get; set; }

        public PersonViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Persons = unit.PersonRepo.Retrieve();
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    if (SelectedPerson == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "Delete":
                    if (SelectedPerson == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return true;
            }
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}