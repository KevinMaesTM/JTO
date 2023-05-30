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
            Themes = unit.ThemeRepo.Retrieve();
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    if (SelectedTheme == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "Add":
                    if (SelectedTheme == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "Delete":
                    if (SelectedTheme == null)
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
                    ThemeDetailViewModel tdvm = new ThemeDetailViewModel(DVM, SelectedTheme);
                    ThemeDetailView tdv = new ThemeDetailView();
                    tdv.DataContext = tdvm;
                    DVM.Content = tdv;
                    break;

                case "Add":
                    ThemeDetailViewModel tdvm2 = new ThemeDetailViewModel(DVM);
                    ThemeDetailView tdv2 = new ThemeDetailView();
                    tdv2.DataContext = tdvm2;
                    DVM.Content = tdv2;
                    break;

                case "Delete":
                    try
                    {
                        unit.ThemeRepo.Delete(SelectedTheme);
                        unit.Save();
                        Themes = unit.ThemeRepo.Retrieve();
                    }
                    catch (Exception ex)
                    {
                        unit.Reload(SelectedTheme);
                        MessageBox.Show("Er ging iets fout. Mogelijk wordt het geselecteerde thema nog gebruikt.");
                    }
                    break;
            }
        }
    }
}