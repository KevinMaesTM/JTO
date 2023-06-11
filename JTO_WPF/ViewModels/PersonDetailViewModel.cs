using DAL.Data.UnitOfWork;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_MODELS;
using System.Xml.Linq;
using JTO_WPF.Views;
using System.Text.RegularExpressions;
using System.Windows;

namespace JTO_WPF.ViewModels
{
    internal class PersonDetailViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public string Mode { get; set; }
        public string Name { get; set; }
        public Person Person { get; set; }
        public string SelectedSex { get; set; }
        public List<string> SexOptions { get; set; } = new List<string>() { "Man", "Vrouw" };

        public PersonDetailViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Person = new Person();
            Mode = "Toevoegen";
            Name = "";
        }

        public PersonDetailViewModel(DashboardViewModel dvm, Person person)
        {
            DVM = dvm;
            Person = person;
            Mode = "Wijzig";
            Name = Person.Name;
            if (Person.Sex == true)
                SelectedSex = "Man";
            else
                SelectedSex = "Vrouw";
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            string errors = "";
            switch (parameter.ToString())
            {
                case "Save":
                    errors = ValidateInput();
                    if (string.IsNullOrEmpty(errors))
                    {
                        if (SelectedSex == "Man")
                            Person.Sex = true;
                        else if (SelectedSex == "Vrouw")
                            Person.Sex = false;

                        if (Person.PersonID == 0)
                        {
                            unit.PersonRepo.Create(Person);
                            unit.Save();
                        }
                        else
                        {
                            Person.Name = Name;
                            unit.PersonRepo.Update(Person);
                            unit.Save();
                        }
                        var pvm = new PersonViewModel(DVM);
                        var pv = new PersonView();
                        pv.DataContext = pvm;
                        DVM.Content = pv;
                        break;
                    }
                    else
                    {
                        MessageBox.Show(errors, "Oh no, errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }

                case "Cancel":
                    var pvm2 = new PersonViewModel(DVM);
                    var pv2 = new PersonView();
                    pv2.DataContext = pvm2;
                    DVM.Content = pv2;
                    break;
            }
        }

        public string ValidateInput()
        {
            string result = "";
            if (string.IsNullOrEmpty(Person.Name))
                result += "Voornaam is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Person.Surname))
                result += "Famillienaam is een verplicht veld!" + Environment.NewLine;
            if (SelectedSex == null)
                result += "Gelieve een geslacht te selecteren." + Environment.NewLine;
            if (string.IsNullOrEmpty(Person.Street))
                result += "Straat is een verplicht veld!" + Environment.NewLine;

            if (string.IsNullOrEmpty(Person.Number))
                result += "Huisnummer is een verplicht veld!" + Environment.NewLine;
            else if (!Person.Number.Any(char.IsDigit))
                result += "Huisnummer moet een nummer (0-9) bevatten!" + Environment.NewLine;

            if (string.IsNullOrEmpty(Person.Zip))
                result += "Postcode is een verplicht veld!" + Environment.NewLine;
            else if (!Person.Zip.Any(char.IsDigit))
                result += "Postcode moet een nummer (0-9) bevatten!" + Environment.NewLine;

            if (string.IsNullOrEmpty(Person.DateOfBirth.ToString()))
                result += "Geboortedatum is een verplicht veld!" + Environment.NewLine;
            else if (!DateTime.TryParse(Person.DateOfBirth.ToString(), out DateTime dateBirth))
                result += "Geboortedatum heeft een ongeldig formaat: dd/MM/yyy" + Environment.NewLine;

            if (string.IsNullOrEmpty(Person.City))
                result += "Gemeente is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Person.Country))
                result += "Land is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Person.Email) && string.IsNullOrEmpty(Person.Phone))
                result += "Gelieve een email of telefoonnummer in te vullen." + Environment.NewLine;
            else
            {
                if (!string.IsNullOrEmpty(Person.Email) && !Regex.IsMatch(Person.Email, "^\\S+@\\S+\\.\\S+$"))
                    result += "Het ingevulde emailadres is ongeldig!." + Environment.NewLine;
                if (!string.IsNullOrEmpty(Person.Phone) && Person.Phone.Count(n => Char.IsLetter(n)) >= 1)
                    result += "Ingevuld telefoonnummer heeft een ongeldig formaat: Mag geen letters bevatten!" + Environment.NewLine;
                if (!string.IsNullOrEmpty(Person.Phone) && (Person.Phone.Count(n => Char.IsNumber(n)) < Person.Phone.Length - 1))
                    result += "Ingevuld telefoonnummer heeft een ongeldig formaat: Mag maximum 1 niet-numeriek character hebben!" + Environment.NewLine;
            }

            return result;
        }
    }
}