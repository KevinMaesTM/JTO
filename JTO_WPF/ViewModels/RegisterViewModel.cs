using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Security.Cryptography;
using JTO_Models;
using JTO_WPF.Views;
using DAL.Data.UnitOfWork;
using DAL.Data;
using System.Collections.ObjectModel;

namespace JTO_WPF.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? RepeatPassword { get; set; }
        public bool ErrorMessageIsShown { get; set; }
        public User? User { get; set; }
        public RegisterViewModel()
        {
            ErrorMessageIsShown = false;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Register": Register(); break;
                case "GoBack": Back(); break;
            }
        }

        private void Back()
        {
            var vm = new LoginViewModel();
            var view = new LoginView();
            view.DataContext = vm;
            view.Show();
            App.Current.Windows[0].Close();
            return;
        }

        private void Register()
        {
            User = unit.UserRepo.Retrieve().FirstOrDefault(x => x.UserName == UserName);

            if (User != null || UserName == null || Password == null || RepeatPassword == null || Password != RepeatPassword)
            {
                ErrorMessageIsShown = true;
                return;
            }

            string hashedPassword = ComputeSha256Hash(Password);
            User newUser = new User(UserName, hashedPassword);
            unit.UserRepo.Create(newUser);
            unit.Save();

            var vm = new DashboardViewModel(newUser);
            var view = new DashboardView();
            view.DataContext = vm;
            view.Show();
            App.Current.Windows[0].Close();
            return;
        }

        private string ComputeSha256Hash(string plainData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}