using JTO_Models;
using JTO_WPF.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JTO_WPF.ViewModels
{
    internal class DashboardViewModel : BaseViewModel
    {
        public UserControl Content { get; set; }
        public User User { get; set; }

        public DashboardViewModel(User user)
        {
            User = user;
            var gtvm = new GroupTourViewModel(this);
            var gtview = new GroupTripView();
            gtview.DataContext = gtvm;
            Content = gtview;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowGroupTrips": ShowGroupTrips(); break;
                case "ShowAgeCategories": ShowAgeCategories(); break;
                case "ShowTrainings": ShowTrainings(); break;
                case "ShowThemes": ShowThemes(); break;
                case "ShowDestinations": ShowDestinations(); break;
                case "ShowRoles": ShowRoles(); break;
                case "Logout": Logout(); break;
                case "ShowPersons": ShowPersons(); break;
                case "CloseApplication": CloseApplication(); break;
            }
        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }

        private void Logout()
        {
            var lvm = new LoginViewModel();
            var lview = new LoginView();
            lview.DataContext = lvm;
            lview.Show();
            App.Current.Windows[0].Close();
            return;
        }

        private void ShowAgeCategories()
        {
            var gtvm = new AgeCategoryViewModel(this);
            var gtview = new AgeCategoryView();
            gtview.DataContext = gtvm;
            Content = gtview;
        }

        private void ShowDestinations()
        {
            var dvm = new DestinationViewModel(this);
            var dv = new DestinationView();
            dv.DataContext = dvm;
            Content = dv;
        }

        private void ShowGroupTrips()
        {
            var gtvm = new GroupTourViewModel(this);
            var gtview = new GroupTripView();
            gtview.DataContext = gtvm;
            Content = gtview;
        }

        private void ShowPersons()
        {
            var pvm = new PersonViewModel(this);
            var pv = new PersonView();
            pv.DataContext = pvm;
            Content = pv;
        }

        private void ShowRoles()
        {
            var roVM = new RoleOverviewViewModel(this);
            var roV = new RoleOverviewView();
            roV.DataContext = roVM;
            Content = roV;
        }

        private void ShowThemes()
        {
            var tvm = new ThemeViewModel(this);
            var tv = new ThemeView();
            tv.DataContext = tvm;
            Content = tv;
        }

        private void ShowTrainings()
        {
            var cvm = new TrainingViewModel(this);
            var tview = new TrainingView();
            tview.DataContext = cvm;
            Content = tview;
        }
    }
}