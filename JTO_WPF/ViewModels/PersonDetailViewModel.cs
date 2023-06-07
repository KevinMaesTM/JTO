using DAL.Data.UnitOfWork;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_MODELS;
using System.Xml.Linq;
using JTO_WPF.Views;

namespace JTO_WPF.ViewModels
{
    internal class PersonDetailViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public string Mode { get; set; }
        public string Name { get; set; }
        public Person Person { get; set; }

        public PersonDetailViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Person = new Person();
            Mode = "Toevoegen";
            Name = "";
        }

        public PersonDetailViewModel(DashboardViewModel dvm, Person person)
        {
            DVM = dvm;
            Person = person;
            Mode = "Wijzig";
            Name = Person.Name;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Add":
                    return true;

                case "Cancel":
                    return true;

                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Add":
                    if (Person.Name == null)
                    {
                        Person t = new Person();
                        unit.PersonRepo.Create(t);
                        unit.Save();
                    }
                    else
                    {
                        Person.Name = Name;
                        unit.PersonRepo.Update(Person);
                        unit.Save();
                    }
                    var pvm = new PersonViewModel(DVM);
                    var pv = new PersonView();
                    pv.DataContext = pvm;
                    DVM.Content = pv;
                    break;

                case "Cancel":
                    var pvm2 = new PersonViewModel(DVM);
                    var pv2 = new PersonView();
                    pv2.DataContext = pvm2;
                    DVM.Content = pv2;
                    break;
            }
        }
    }
}