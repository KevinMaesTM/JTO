using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_Tests.Partials
{
    [TestFixture]
    public class AgeCategoryTest
    {
        [Test]
        public void ToStringReturnsCorrectFormat()
        {
            //Arrange
            AgeCategory category = new AgeCategory(10, 12);

            //Act
            string output = category.ToString();

            //Assert
            Assert.AreEqual("(10 - 12)", output);
        }
    }
}
