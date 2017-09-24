﻿using EmpleoDotNet.WebAPI.Helpers;
using FluentAssertions;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.WebAPI.Tests.HelperTests
{
    [TestFixture]
    internal class EnumExtensionsTests
    {
        [Test]
        public void GetDisplayName_AnyEnum_ReturnsNonEmptyString()
        {
            //Act
            var displayName = TestEnum.Test1.GetDisplayName();

            //Assert
            displayName.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
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
