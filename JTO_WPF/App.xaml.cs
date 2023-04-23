using JTO_WPF.ViewModels;
using JTO_WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JTO_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var vm = new LoginViewModel();
            var view = new LoginView();
            view.DataContext = vm;
            view.Show();
        }
    }
}
