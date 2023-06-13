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
        public string DateOfBirth { get; set; }
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
            DateOfBirth = null;
        }

        public PersonDetailViewModel(DashboardViewModel dvm, Person person)
        {
            DVM = dvm;
            Person = person;
            //Name = Person.Name;
            DateOfBirth = Person.DateOfBirth.ToString("dd/MM/yyyy");
            if (Person.Sex == true)
                SelectedSex = "Man";
            else
                SelectedSex = "Vrouw";
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public void CreatePerson()
        {
            try
            {
                unit.PersonRepo.Create(Person);
                unit.Save();

                DVM.SnackbarContent = $"Persoon '{Person.Name} {Person.Surname} is aangemaakt!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.", "Er is een fout opgetreden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            ShowPersons();
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
                        Person.DateOfBirth = DateTime.Parse(DateOfBirth);
                        if (SelectedSex == "Man")
                            Person.Sex = true;
                        else if (SelectedSex == "Vrouw")
                            Person.Sex = false;

                        if (Person.PersonID == 0)
                            CreatePerson();
                        else
                            UpdatePerson();
                    }
                    else
                        MessageBox.Show(errors, "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                case "Cancel": ShowPersons(); break;
                default: break;
            }
        }

        public void ShowPersons()
        {
            var pvm = new PersonViewModel(DVM);
            var pv = new PersonView();
            pv.DataContext = pvm;
            DVM.Content = pv;
        }

        public void UpdatePerson()
        {
            try
            {
                unit.PersonRepo.Update(Person);
                unit.Save();

                DVM.SnackbarContent = $"Gegevens voor '{Person.Name} {Person.Surname} zijn aangepast.";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.", "Er is een fout opgetreden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            ShowPersons();
        }

        public string ValidateInput()
        {
            string result = "";
            // Validation on First + lastname
            if (string.IsNullOrEmpty(Person.Name))
                result += "Voornaam is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Person.Surname))
                result += "Famillienaam is een verplicht veld!" + Environment.NewLine;
            // Validation that a sex is selected from the combobox
            if (SelectedSex == null)
                result += "Gelieve een geslacht te selecteren." + Environment.NewLine;
            if (string.IsNullOrEmpty(Person.Street))
                result += "Straat is een verplicht veld!" + Environment.NewLine;
            // Validates if housenumber is filled in. If it is filled in, checks if it contains at
            // least 1 number (Ex. ABC is not a valid housenumber, ABC1/1ABC is)
            if (string.IsNullOrEmpty(Person.Number))
                result += "Huisnummer is een verplicht veld!" + Environment.NewLine;
            else if (!Person.Number.Any(char.IsDigit))
                result += "Huisnummer moet een nummer (0-9) bevatten!" + Environment.NewLine;
            // Validates if zipcode is filled in. If it is fileld in, checks if it contains at least
            // 1 number (Ex. ABC is not a valid zipcode, ABC1/1ABC is)
            if (string.IsNullOrEmpty(Person.Zip))
                result += "Postcode is een verplicht veld!" + Environment.NewLine;
            else if (!Person.Zip.Any(char.IsDigit))
                result += "Postcode moet een nummer (0-9) bevatten!" + Environment.NewLine;

            // Validates if DateOfBirth is a filled in.
            if (string.IsNullOrEmpty(Person.DateOfBirth.ToString("dd/MM/yyyy")))
                result += "Geboortedatum is een verplicht veld!" + Environment.NewLine;
            // If it is filled in, perfoms 2 more validations: Correct format (dd/MM/yyyy) and if
            // the date is in the past
            else
            {
                if (!DateTime.TryParse(Person.DateOfBirth.ToString("dd/MM/yyyy"), out DateTime dateBirth))
                    result += "Geboortedatum heeft een ongeldig formaat: dd/MM/yyy" + Environment.NewLine;
                if (dateBirth >= DateTime.Now)
                    result += "De ingevulde geboortedatum ligt niet in het verleden." + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(Person.City))
                result += "Gemeente is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Person.Country))
                result += "Land is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Person.Email))
                result += "Email adres is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (!string.IsNullOrEmpty(Person.Email) && !Regex.IsMatch(Person.Email, "^\\S+@\\S+\\.\\S+$"))
                    result += "Het ingevulde emailadres is ongeldig!." + Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(Person.Phone) && Person.Phone.Count(n => Char.IsLetter(n)) >= 1)
                result += "Het ingevuldg telefoonnummer heeft een ongeldig formaat: Mag geen letters bevatten!" + Environment.NewLine;
            if (!string.IsNullOrEmpty(Person.Phone) && (Person.Phone.Count(n => Char.IsNumber(n)) < Person.Phone.Length - 1))
                result += "Het ingevulde telefoonnummer heeft een ongeldig formaat: Mag maximum 1 niet-numeriek character hebben!" + Environment.NewLine;

            return result;
        }
    }
}