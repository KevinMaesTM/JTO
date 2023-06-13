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
        public DashboardViewModel DVM { get; set; }
        public string Mode { get; set; }
        public string Name { get; set; }
        public Theme Theme { get; set; }

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
            return true;
        }

        public void CreateTheme()
        {
            Theme t = new Theme(Name);
            unit.ThemeRepo.Create(t);
            unit.Save();
            DVM.SnackbarContent = $"Nieuw thema '{Theme.Name}' aangemaakt!";

            ShowThemes();
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Add":
                    if (Theme.ThemeID == 0)
                        CreateTheme();
                    else
                        UpdateTheme();
                    break;

                case "Cancel": ShowThemes(); break;
                default: break;
            }
        }

        public void ShowThemes()
        {
            var tvm = new ThemeViewModel(DVM);
            var tv = new ThemeView();
            tv.DataContext = tvm;
            DVM.Content = tv;
        }

        public void UpdateTheme()
        {
            Theme.Name = Name;
            unit.ThemeRepo.Update(Theme);
            unit.Save();
            DVM.SnackbarContent = $"Thema '{Theme.Name}' aangepast.";

            ShowThemes();
        }
    }
}