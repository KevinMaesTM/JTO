using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_Models;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkTraineeRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeTrainee()
        {
            //Arrange
            ObservableCollection<Trainee> Trainees;

            //Act
            Trainees = new ObservableCollection<Trainee>(unitOfWork.TraineeRepo.Retrieve());

            //Assert
            Assert.NotNull(Trainees);
            Assert.IsInstanceOf<ObservableCollection<Trainee>>(Trainees);
        }
    }
}
