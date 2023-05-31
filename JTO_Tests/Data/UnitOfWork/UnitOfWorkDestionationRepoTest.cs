using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkDestinationRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeDestination()
        {
            //Arrange
            ObservableCollection<Destination> Destinations;

            //Act
            Destinations = new ObservableCollection<Destination>(unitOfWork.DestinationRepo.Retrieve());

            //Assert
            Assert.NotNull(Destinations);
            Assert.IsInstanceOf<ObservableCollection<Destination>>(Destinations);
        }
    }
}
