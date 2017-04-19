using EmpleoDotNet.WebAPI.Helpers;
using FluentAssertions;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.WebAPI.Tests.Helpers
{
    [TestFixture]
    internal class EnumExtensionsTests
    {
        public void GetDisplayName_AnyEnum_ReturnsNonEmptyString()
        {
            //Act
            var displayName = TestEnum.Test1.GetDisplayName();

            //Assert
            displayName.Should().NotBeNullOrWhiteSpace();
        }

        public void GetDisplayName_AnyEnum_ReturnsDisplayName()
        {
            // Act
            var displayName = TestEnum.Test1.GetDisplayName();

            //Assert
            displayName.Should().Be("Test 1");
        }
    }

    internal enum TestEnum
    {
        [Display(Name = "Test 1")]
        Test1
    }
}