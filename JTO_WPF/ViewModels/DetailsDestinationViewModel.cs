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
    internal class DetailsDestinationViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public string City { get; set; }
        public string Country { get; set; }
        public Destination Destination { get; set; }
        public DashboardViewModel DVM { get; set; }
        public string HouseNumber { get; set; }
        public string Name { get; set; }
        public string Streetname { get; set; }
        public string Zipcode { get; set; }

        public DetailsDestinationViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            this.Destination = new Destination();
        }

        public DetailsDestinationViewModel(DashboardViewModel dvm, Destination destination)
        {
            DVM = dvm;
            this.Destination = destination;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "SaveDestination":
                    if (Destination.DestinationID == 0)
                    {
                        unit.DestinationRepo.Create(Destination);
                        unit.Save();
                    }
                    break;
            }
        }
    }
}