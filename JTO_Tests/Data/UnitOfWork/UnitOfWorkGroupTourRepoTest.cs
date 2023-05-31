using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkGroupTourRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeGroupTour()
        {
            //Arrange
            ObservableCollection<GroupTour> GroupTours;

            //Act
            GroupTours = new ObservableCollection<GroupTour>(unitOfWork.GroupTourRepo.Retrieve());

            //Assert
            Assert.NotNull(GroupTours);
            Assert.IsInstanceOf<ObservableCollection<GroupTour>>(GroupTours);
        }
    }
}
