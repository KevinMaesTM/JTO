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
    public class LoginViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public bool ErrorMessageIsShown { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public ObservableCollection<User> Users { get; set; }

        public LoginViewModel()
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
                case "Login": Login(); break;
            }
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

        private void Login()
        {
            if (UserName == null || Password == null)
            {
                ErrorMessageIsShown = true;
                return;
            }

            string hashedPassword = ComputeSha256Hash(Password);

            Users = new ObservableCollection<User>(unit.UserRepo.Retrieve());
            User loggedUser = Users.FirstOrDefault(x => x.UserName == UserName);
            if (loggedUser != null && loggedUser.Password == hashedPassword)
            {
                var vm = new DashboardViewModel(loggedUser);
                var view = new DashboardView();
                view.DataContext = vm;
                view.Show();
                App.Current.Windows[0].Close();

                //TODO: Implement this
                //User user = GetUserByUserName(UserName);

                //Voor testing purposes: Admin als SHA256 encrypted password
                /*User user = new User("Admin", "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f");

                string hashedPassword = ComputeSha256Hash(Password);

                if (user.Password == hashedPassword) {
                    var vm = new DashboardViewModel(user);
                    var view = new DashboardView();
                    view.DataContext = vm;
                    view.Show();
                    App.Current.Windows[0].Close();
                */
            }
            ErrorMessageIsShown = true;
            return;
        }
    }
}