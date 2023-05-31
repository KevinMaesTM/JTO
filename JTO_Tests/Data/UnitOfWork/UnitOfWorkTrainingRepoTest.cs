using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkTrainingRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeTraining()
        {
            //Arrange
            ObservableCollection<Training> Trainings;

            //Act
            Trainings = new ObservableCollection<Training>(unitOfWork.TrainingRepo.Retrieve());

            //Assert
            Assert.NotNull(Trainings);
            Assert.IsInstanceOf<ObservableCollection<Training>>(Trainings);
        }
    }
}
