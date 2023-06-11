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
    internal class AgeCategoryViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public IEnumerable<AgeCategory> AgeCategories { get; set; }
        public DashboardViewModel DVM { get; set; }
        public AgeCategory SelectedAgeCategory { get; set; }

        public AgeCategoryViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            AgeCategories = unit.AgeCategoryRepo.Retrieve(ac => ac.IsActive == true || ac.IsActive == null);
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    if (SelectedAgeCategory == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "Delete":
                    if (SelectedAgeCategory == null)
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
                    DetailsAgeCategoryViewModel acVM = new DetailsAgeCategoryViewModel(DVM, SelectedAgeCategory);
                    DetailsAgeCategoryView daV = new DetailsAgeCategoryView();
                    daV.DataContext = acVM;
                    DVM.Content = daV;
                    break;

                case "Add":
                    DetailsAgeCategoryViewModel acVM2 = new DetailsAgeCategoryViewModel(DVM);
                    DetailsAgeCategoryView daV2 = new DetailsAgeCategoryView();
                    daV2.DataContext = acVM2;
                    DVM.Content = daV2;
                    break;

                case "Delete":
                    try
                    {
                        SelectedAgeCategory.IsActive = false;
                        unit.AgeCategoryRepo.Update(SelectedAgeCategory);
                        unit.Save();
                        AgeCategories = unit.AgeCategoryRepo.Retrieve(ac => ac.IsActive == true || ac.IsActive == null);
                    }
                    catch (Exception ex)
                    {
                        unit.Reload(SelectedAgeCategory);
                        MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.");
                    }
                    break;
            }
        }
    }
}