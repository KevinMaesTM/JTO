using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkParticipantRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeParticipant()
        {
            //Arrange
            ObservableCollection<Participant> Participants;

            //Act
            Participants = new ObservableCollection<Participant>(unitOfWork.ParticipantRepo.Retrieve());

            //Assert
            Assert.NotNull(Participants);
            Assert.IsInstanceOf<ObservableCollection<Participant>>(Participants);
        }
    }
}
