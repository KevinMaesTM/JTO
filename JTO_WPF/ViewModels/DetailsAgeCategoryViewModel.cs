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
    internal class DetailsAgeCategoryViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public AgeCategory AgeCategory { get; set; }
        public string MaxAge { get; set; }
        public string MinAge { get; set; }
        private DashboardViewModel DVM { get; set; }

        public DetailsAgeCategoryViewModel(DashboardViewModel dVM)
        {
            AgeCategory = new AgeCategory();
            DVM = dVM;
        }

        public DetailsAgeCategoryViewModel(DashboardViewModel dVM, AgeCategory ageCategory)
        {
            AgeCategory = ageCategory;
            MinAge = AgeCategory.MinAge.ToString();
            MaxAge = AgeCategory.MaxAge.ToString();
            DVM = dVM;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Save":
                case "Cancel":
                    return true;

                default:
                    return false;
            }
        }

        public void CreateAgeCategory()
        {
            try
            {
                unit.AgeCategoryRepo.Create(AgeCategory);
                unit.Save();
                DVM.SnackbarContent = $"Niewe leeftijdscategorie '{AgeCategory.MinAge}j - {AgeCategory.MaxAge}j' aangemaakt.";
            }
            catch   (Exception ex)
            {
                MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.", "Er is een fout opgetreden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public override void Execute(object parameter)
        {
            // Reset errors with each CRUD operation
            string errors = "";
            switch (parameter.ToString())
            {
                case "Save":
                    errors = ValidateInput();
                    if (string.IsNullOrEmpty(errors))
                    {
                        AgeCategory.MinAge = int.Parse(MinAge);
                        AgeCategory.MaxAge = int.Parse(MaxAge);
                        if (AgeCategory.MinAge >= AgeCategory.MaxAge)
                        {
                            MessageBox.Show("Minimum leeftijd moet kleiner zijn dan de maxium leeftijd!", "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                        // Check if it's a new AgeCategory
                        if (AgeCategory.AgeCategoryID == 0)
                            CreateAgeCategory();
                        else
                            UpdateAgeCategory();

                        ShowAgeCategories();
                    }
                    else
                        MessageBox.Show(errors, "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                case "Cancel": ShowAgeCategories(); break;
                default: break;
            }
        }

        public void ShowAgeCategories()
        {
            var acVM = new AgeCategoryViewModel(DVM);
            var acV = new AgeCategoryView();
            acV.DataContext = acVM;
            DVM.Content = acV;
        }

        public void UpdateAgeCategory()
        {
            try
            {
                unit.AgeCategoryRepo.Update(AgeCategory);
                unit.Save();
                DVM.SnackbarContent = $"Leeftijdscategorie '{AgeCategory.MinAge}j - {AgeCategory.MaxAge}j' aangepast.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.", "Er is een fout opgetreden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public string ValidateInput()
        {
            string result = "";
            // Check input value of MinAge
            if (string.IsNullOrEmpty(MinAge))
                result += "Minimum leeftijd is een verplicht veld." + Environment.NewLine;
            else if (!int.TryParse(MinAge.ToString(), out int minAge))
                result += "Minimum leeftijd is geen geldig getal!" + Environment.NewLine;
            // Check input value of MaxAge
            if (string.IsNullOrEmpty(MaxAge))
                result += "Maximum leeftijd is een verplicht veld." + Environment.NewLine;
            else if (!int.TryParse(MaxAge.ToString(), out int maxAge))
                result += "Maximum leeftijd is geen geldig getal!" + Environment.NewLine;

            // Check if MinAge < MaxAge

            return result;
        }
    }
}