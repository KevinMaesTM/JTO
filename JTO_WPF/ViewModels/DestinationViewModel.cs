using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_MODELS;
using JTO_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_WPF.ViewModels
{
    internal class DestinationViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public IEnumerable<Destination> Destinations { get; set; }
        public DashboardViewModel DVM { get; set; }
        public Destination SelectedDestination { get; set; }

        public DestinationViewModel(DashboardViewModel dVM)
        {
            this.DVM = dVM;
            Destinations = unit.DestinationRepo.Retrieve();
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Add":
                    return true;

                case "ShowDetail":
                case "Delete":
                    return (SelectedDestination != null);
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Add":
                    DetailsDestinationViewModel ddVM = new DetailsDestinationViewModel(DVM);
                    DestinationDetailView ddV = new DestinationDetailView();
                    ddV.DataContext = ddVM;
                    DVM.Content = ddV;
                    break;

                case "ShowDetail":
                    DetailsDestinationViewModel ddVM2 = new DetailsDestinationViewModel(DVM, SelectedDestination);
                    DestinationDetailView ddV2 = new DestinationDetailView();
                    ddV2.DataContext = ddVM2;
                    DVM.Content = ddV2;
                    break;
            }
        }
    }
}