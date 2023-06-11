using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_WPF.Views;
using System.Windows;

namespace JTO_WPF.ViewModels
{
    internal class PersonViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public Person SelectedPerson { get; set; }

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
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    PersonDetailViewModel pdvm = new PersonDetailViewModel(DVM, SelectedPerson);
                    PersonDetailView pdv = new PersonDetailView();
                    pdv.DataContext = pdvm;
                    DVM.Content = pdv;
                    break;

                case "Add":
                    PersonDetailViewModel pdvm2 = new PersonDetailViewModel(DVM);
                    PersonDetailView pdv2 = new PersonDetailView();
                    pdv2.DataContext = pdvm2;
                    DVM.Content = pdv2;
                    break;

                case "Delete":
                    try
                    {
                        unit.PersonRepo.Delete(SelectedPerson);
                        unit.Save();
                        Persons = unit.PersonRepo.Retrieve();
                    }
                    catch (Exception ex)
                    {
                        unit.Reload(SelectedPerson);
                        MessageBox.Show("Er ging iets fout. Mogelijk wordt de geselecteerde persoon nog gebruikt.");
                    }
                    break;
            }
        }
    }
}