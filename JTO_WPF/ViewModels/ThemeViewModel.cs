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
    internal class ThemeViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public Theme SelectedTheme { get; set; }
        public IEnumerable<Theme> Themes { get; set; }

        public ThemeViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Themes = unit.ThemeRepo.Retrieve(t => t.IsActive == true || t.IsActive == null);
        }

        public void AddTheme()
        {
            ThemeDetailViewModel tdvm = new ThemeDetailViewModel(DVM);
            ThemeDetailView tdv = new ThemeDetailView();
            tdv.DataContext = tdvm;
            DVM.Content = tdv;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                case "Delete":
                    return (SelectedTheme != null);

                case "Add":
                    return (SelectedTheme == null);

                default:
                    return true;
            }
        }

        public void DeleteTheme()
        {
            try
            {
                SelectedTheme.IsActive = false;
                unit.ThemeRepo.Update(SelectedTheme);
                unit.Save();
                Themes = unit.ThemeRepo.Retrieve(t => t.IsActive == true || t.IsActive == null);
            }
            catch (Exception ex)
            {
                unit.Reload(SelectedTheme);
                MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.");
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail": ShowThemeDetails(); break;
                case "Add": AddTheme(); break;
                case "Delete": DeleteTheme(); break;
                default: break;
            }
        }

        public void ShowThemeDetails()
        {
            ThemeDetailViewModel tdvm = new ThemeDetailViewModel(DVM, SelectedTheme);
            ThemeDetailView tdv = new ThemeDetailView();
            tdv.DataContext = tdvm;
            DVM.Content = tdv;
        }
    }
}