using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using NUnit.Framework;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JTO_Tests.Views
{
    [TestFixture]
    public class RegisterViewTest
    {
        [Test]
        public void RegistrationShouldFailForExistingUserName()
        {
            var app = Application.Launch("C:\\Users\\Kevin\\Desktop\\JTO\\JTO_WPF\\bin\\Debug\\net6.0-windows\\JTO_WPF");

            using (var automation = new UIA3Automation())
            {
                var loginWindow = app.GetMainWindow(automation);
                var RegisterButton = loginWindow.FindFirstDescendant(x => x.ByAutomationId("RegisterButton")).AsButton();

                // Act
                RegisterButton.Click();

                var registerWindow = app.GetMainWindow(automation);
                var UserNameInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("UserNameInput")).AsTextBox();
                var PasswordInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("PasswordInput")).AsTextBox();
                var RepeatPasswordInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("RepeatPasswordInput")).AsTextBox();
                var RegisterButton2 = registerWindow.FindFirstDescendant(x => x.ByAutomationId("RegisterButton")).AsButton();

                UserNameInput.Enter("Admin");
                PasswordInput.Enter("Admin");
                RepeatPasswordInput.Enter("Admin");
                RegisterButton2.Click();

                var ErrorMessage = registerWindow.FindFirstDescendant(x => x.ByAutomationId("ErrorMessage")).AsLabel();

                // Assert
                Assert.That(ErrorMessage.Text, Is.EqualTo("Oops something went wrong .."));
                app.Close();
            }
        }

        [Test]
        public void RegistrationShouldFaiIfPasswordsDontMatch()
        {
            var app = Application.Launch("C:\\Users\\Kevin\\Desktop\\JTO\\JTO_WPF\\bin\\Debug\\net6.0-windows\\JTO_WPF");

            using (var automation = new UIA3Automation())
            {
                var loginWindow = app.GetMainWindow(automation);
                var RegisterButton = loginWindow.FindFirstDescendant(x => x.ByAutomationId("RegisterButton")).AsButton();

                // Act
                RegisterButton.Click();

                var registerWindow = app.GetMainWindow(automation);
                var UserNameInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("UserNameInput")).AsTextBox();
                var PasswordInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("PasswordInput")).AsTextBox();
                var RepeatPasswordInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("RepeatPasswordInput")).AsTextBox();
                var RegisterButton2 = registerWindow.FindFirstDescendant(x => x.ByAutomationId("RegisterButton")).AsButton();

                UserNameInput.Enter("Admin");
                PasswordInput.Enter("Admin");
                RepeatPasswordInput.Enter("Admi");
                RegisterButton2.Click();

                var ErrorMessage = registerWindow.FindFirstDescendant(x => x.ByAutomationId("ErrorMessage")).AsLabel();

                // Assert
                Assert.That(ErrorMessage.Text, Is.EqualTo("Oops something went wrong .."));
                app.Close();
            }
        }

        [Test]
        public void RegistrationShouldPassForNewUsers()
        {
            var app = Application.Launch("C:\\Users\\Kevin\\Desktop\\JTO\\JTO_WPF\\bin\\Debug\\net6.0-windows\\JTO_WPF");

            using (var automation = new UIA3Automation())
            {
                var loginWindow = app.GetMainWindow(automation);
                var RegisterButton = loginWindow.FindFirstDescendant(x => x.ByAutomationId("RegisterButton")).AsButton();

                // Act
                RegisterButton.Click();

                var registerWindow = app.GetMainWindow(automation);
                var UserNameInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("UserNameInput")).AsTextBox();
                var PasswordInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("PasswordInput")).AsTextBox();
                var RepeatPasswordInput = registerWindow.FindFirstDescendant(x => x.ByAutomationId("RepeatPasswordInput")).AsTextBox();
                var RegisterButton2 = registerWindow.FindFirstDescendant(x => x.ByAutomationId("RegisterButton")).AsButton();

                UserNameInput.Enter("NewUser");
                PasswordInput.Enter("NewUser");
                RepeatPasswordInput.Enter("NewUser");
                RegisterButton2.Click();

                Thread.Sleep(1000);
                var dashboardWindow = app.GetMainWindow(automation);
                var UserName = dashboardWindow.FindFirstDescendant(x => x.ByAutomationId("UserName")).AsLabel();

                // Assert
                Assert.That(UserName.Text, Is.EqualTo("NewUser"));
                app.Close();
            }
        }
    }
}
