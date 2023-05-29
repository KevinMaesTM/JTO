using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_WPF.Views;
using System.Reflection.Metadata;

namespace JTO_WPF.ViewModels
{
    internal class ThemeDetailViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public Theme Theme { get; set; }
        public string Name { get; set; }
        public DashboardViewModel DVM { get; set; }

        public ThemeDetailViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Theme = new Theme();
            Name = "";
        }

        public ThemeDetailViewModel(DashboardViewModel dvm, Theme theme)
        {
            DVM = dvm;
            Theme = theme;
            Name = Theme.Name;
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
                    Theme t = new Theme(Name);
                    unit.ThemeRepo.Create(t);
                    unit.Save();
                    break;
                case "Cancel":
                    var tvm = new ThemeViewModel(DVM);
                    var tv = new ThemeView();
                    tv.DataContext = tvm;
                    DVM.Content = tv;
                    break;
            }
        }
    }
}