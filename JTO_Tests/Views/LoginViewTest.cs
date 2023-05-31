using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using NUnit.Framework;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JTO_Tests.Views
{
    [TestFixture]
    public class LoginViewTest
    {
        [Test]
        public void LoginShouldFailWhenUsingIncorrectCredentials()
        {
            var app = Application.Launch("..\\..\\..\\..\\JTO_WPF\\bin\\Debug\\net6.0-windows\\JTO_WPF");

            using (var automation = new UIA3Automation())
            {
                var loginWindow = app.GetMainWindow(automation);

                var UserNameInput = loginWindow.FindFirstDescendant(x => x.ByAutomationId("UserNameInput")).AsTextBox();
                var PasswordInput = loginWindow.FindFirstDescendant(x => x.ByAutomationId("PasswordInput")).AsTextBox();
                var LoginButton = loginWindow.FindFirstDescendant(x => x.ByAutomationId("LoginButton")).AsButton();

                // Act
                UserNameInput.Enter("admin");
                PasswordInput.Enter("admin");

                LoginButton.Click();
                var ErrorMessage = loginWindow.FindFirstDescendant(x => x.ByAutomationId("ErrorMessage")).AsLabel();

                // Assert
                Assert.That(ErrorMessage.Text, Is.EqualTo("Oops something went wrong .."));
                app.Close();
            }
        }

        [Test]
        public void LoginShouldPassWhenUsingCorrectCredentials()
        {
            var app = Application.Launch("..\\..\\..\\..\\JTO_WPF\\bin\\Debug\\net6.0-windows\\JTO_WPF");

            using (var automation = new UIA3Automation())
            {
                var loginWindow = app.GetMainWindow(automation);

                var UserNameInput = loginWindow.FindFirstDescendant(x => x.ByAutomationId("UserNameInput")).AsTextBox();
                var PasswordInput = loginWindow.FindFirstDescendant(x => x.ByAutomationId("PasswordInput")).AsTextBox();
                var LoginButton = loginWindow.FindFirstDescendant(x => x.ByAutomationId("LoginButton")).AsButton();

                // Act
                UserNameInput.Enter("Admin");
                PasswordInput.Enter("Admin");

                LoginButton.Click();

                Thread.Sleep(1000);
                var dashboardWindow = app.GetMainWindow(automation);
                var UserName = dashboardWindow.FindFirstDescendant(x => x.ByAutomationId("UserName")).AsLabel();   

                // Assert
                Assert.That(UserName.Text, Is.EqualTo("Admin"));
                app.Close();
            }
        }
    }
}
