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
        public string Mode { get; set; }
        public DashboardViewModel DVM { get; set; }

        public ThemeDetailViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Theme = new Theme();
            Mode = "Toevoegen";
            Name = "";
        }

        public ThemeDetailViewModel(DashboardViewModel dvm, Theme theme)
        {
            DVM = dvm;
            Theme = theme;
            Mode = "Wijzig";
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
                    if(Theme.Name == null)
                    {
                        Theme t = new Theme(Name);
                        unit.ThemeRepo.Create(t);
                        unit.Save();
                    } else
                    {
                        Theme.Name = Name;
                        unit.ThemeRepo.Update(Theme);
                        unit.Save();
                    }
                    var tvm = new ThemeViewModel(DVM);
                    var tv = new ThemeView();
                    tv.DataContext = tvm;
                    DVM.Content = tv;
                    break;
                case "Cancel":
                    var tvm2 = new ThemeViewModel(DVM);
                    var tv2 = new ThemeView();
                    tv2.DataContext = tvm2;
                    DVM.Content = tv2;
                    break;
            }
        }
    }
}