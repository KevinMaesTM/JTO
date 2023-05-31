using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkRoleRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeRole()
        {
            //Arrange
            ObservableCollection<Role> Roles;

            //Act
            Roles = new ObservableCollection<Role>(unitOfWork.RoleRepo.Retrieve());

            //Assert
            Assert.NotNull(Roles);
            Assert.IsInstanceOf<ObservableCollection<Role>>(Roles);
        }
    }
}
