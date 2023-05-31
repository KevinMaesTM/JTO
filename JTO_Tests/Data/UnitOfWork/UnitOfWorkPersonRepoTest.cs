using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkPersonRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectyionOfTypePerson()
        {
            //Arrange
            ObservableCollection<Person> Persons;

            //Act
            Persons = new ObservableCollection<Person>(unitOfWork.PersonRepo.Retrieve());

            //Assert
            Assert.NotNull(Persons);
            Assert.IsInstanceOf<ObservableCollection<Person>>(Persons);
        }
    }
}
