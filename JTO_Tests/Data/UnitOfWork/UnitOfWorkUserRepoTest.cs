using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_Models;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkUserRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeUser()
        {
            //Arrange
            ObservableCollection<User> Users;

            //Act
            Users = new ObservableCollection<User>(unitOfWork.UserRepo.Retrieve());

            //Assert
            Assert.NotNull(Users);
            Assert.IsInstanceOf<ObservableCollection<User>>(Users);
        }
    }
}
