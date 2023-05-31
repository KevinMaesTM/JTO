using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkThemaRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeTheme()
        {
            //Arrange
            ObservableCollection<Theme> Themes;

            //Act
            Themes = new ObservableCollection<Theme>(unitOfWork.ThemeRepo.Retrieve());

            //Assert
            Assert.NotNull(Themes);
            Assert.IsInstanceOf<ObservableCollection<Theme>>(Themes);
        }
    }
}
