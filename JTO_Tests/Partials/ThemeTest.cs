using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_Tests.Partials
{
    [TestFixture]
    public class ThemeTest
    {
        [Test]
        public void ToStringReturnsCorrectFormat()
        {
            //Arrange
            Theme theme = new Theme("Avontuur");

            //Act
            string output = theme.ToString();

            //Assert
            Assert.AreEqual("Avontuur", output);
        }
    }
}
