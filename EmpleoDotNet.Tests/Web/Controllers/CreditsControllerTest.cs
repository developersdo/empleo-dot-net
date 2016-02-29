using System.Web.Mvc;
using EmpleoDotNet.Controllers;
using FluentAssertions;
using NUnit.Framework;

namespace EmpleoDotNet.Tests.Web.Controllers
{
    [TestFixture]
    public class CreditsControllerTest
    {
        [Test]
        public void Index_ReturnsView()
        {
            // Arrange
            var sut = new CreditsController();

            // Act
            var result = (ViewResult)sut.Index();

            // Assert
            result.ViewName.Should().BeEmpty();
        }
    }
}
