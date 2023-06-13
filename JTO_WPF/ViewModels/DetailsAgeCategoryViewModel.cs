﻿using DAL.Data.UnitOfWork;
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
        private DashboardViewModel DVM { get; set; }

        public DetailsAgeCategoryViewModel(DashboardViewModel dVM)
        {
            AgeCategory = new AgeCategory();
            DVM = dVM;
        }

        public DetailsAgeCategoryViewModel(DashboardViewModel dVM, AgeCategory ageCategory)
        {
            AgeCategory = ageCategory;
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
            unit.AgeCategoryRepo.Create(AgeCategory);
            unit.Save();

            DVM.SnackbarContent = $"Niewe leeftijdscategorie '{AgeCategory.MinAge}j - {AgeCategory.MaxAge}j' aangemaakt.";
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
            unit.AgeCategoryRepo.Update(AgeCategory);
            unit.Save();

            DVM.SnackbarContent = $"Leeftijdscategorie '{AgeCategory.MinAge}j - {AgeCategory.MaxAge}j' aangepast.";
        }

        public string ValidateInput()
        {
            string result = "";
            // Check input value of MinAge
            if (string.IsNullOrEmpty(AgeCategory.MinAge.ToString()))
                result += "Minimum leeftijd is een verplicht veld." + Environment.NewLine;
            else if (!int.TryParse(AgeCategory.MinAge.ToString(), out int minAge))
                result += "Minimum leeftijd is geen geldig getal!" + Environment.NewLine;
            // Check input value of MaxAge
            if (string.IsNullOrEmpty(AgeCategory.MaxAge.ToString()))
                result += "Maximum leeftijd is een verplicht veld." + Environment.NewLine;
            else if (!int.TryParse(AgeCategory.MaxAge.ToString(), out int maxAge))
                result += "Maximum leeftijd is geen geldig getal!" + Environment.NewLine;

            // Check if MinAge < MaxAge
            if (AgeCategory.MinAge >= AgeCategory.MaxAge)
                result += "Minimum leeftijd moet kleiner zijn dan de maxium leeftijd!" + Environment.NewLine;

            return result;
        }
    }
}