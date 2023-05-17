﻿using JTO_Models;
using JTO_WPF.Views;
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
        public DashboardViewModel(User user) {
            User = user;
            var gtvm = new GroupTourViewModel();
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
                case "ShowPersons": ShowPersons(); break;
            }
        }

        private void ShowGroupTrips()
        {
            var gtvm = new GroupTourViewModel();
            var gtview = new GroupTripView();
            gtview.DataContext = gtvm;
            Content = gtview;
        }

        private void ShowPersons()
        {
            Content = new Views.PersonView();
        }
    }
}
