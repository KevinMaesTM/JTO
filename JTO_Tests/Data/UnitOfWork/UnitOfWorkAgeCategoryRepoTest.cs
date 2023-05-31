using DAL.Data.UnitOfWork;
using FakeItEasy;
using JTO_MODELS;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace JTO_Tests.Data.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkAgeCategoryRepoTest
    {
        private IUnitOfWork unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void RetrieveReturnsObservableCollectionOfTypeAgeCategory()
        {
            //Arrange
            ObservableCollection<AgeCategory> AgeCategories;

            //Act
            AgeCategories = new ObservableCollection<AgeCategory>(unitOfWork.AgeCategoryRepo.Retrieve());

            //Assert
            Assert.NotNull(AgeCategories);
            Assert.IsInstanceOf<ObservableCollection<AgeCategory>>(AgeCategories);
        }
    }
}
