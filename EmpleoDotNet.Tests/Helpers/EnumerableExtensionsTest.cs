using System.Collections.Generic;
using System.Linq;
using EmpleoDotNet.Helpers;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable InvokeAsExtensionMethod
// ReSharper disable RedundantArgumentDefaultValue

namespace EmpleoDotNet.Tests.Helpers
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        [ExpectedException]
        public void ToSelectList_TypeOfTNotClass_ThrowsException()
        {
            var enumerable = new string[] { "primitive", "enumerable" };
            var result = EnumerableExtensions.ToSelectList(enumerable, s => s, s => s, null);
        }

        [Test]
        public void ToSelectList_EmptyEnumerable_ReturnsEmptyList()
        {
            var emptyEnumerable = new MockPerson[] { };
            var result = EnumerableExtensions.ToSelectList(emptyEnumerable, s => s.Id, s => s.Name, null);

            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }

        [Test]
        public void ToSelectList_NullObject_ReturnsNull()
        {
            IEnumerable<MockPerson> nullEnumerable = null;
            var result = EnumerableExtensions.ToSelectList(nullEnumerable, s => s.Id, s => s.Name, null);

            result.Should().BeNull();
        }

        [Test]
        public void ToSelectList_Success()
        {
            // arrange
            var peopleList = new [] {
                new MockPerson {Id = 1, Name = "Diane Parks"},
                new MockPerson {Id = 2, Name = "John Deer"},
                new MockPerson {Id = 3, Name = "Default Person"}
            };

            var defaultPerson = peopleList[2];

            // act
            var result = EnumerableExtensions.ToSelectList(peopleList, s => s.Id, s => s.Name, defaultPerson.Id);

            // assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            var selectListItems = result.ToList();
            for (var i = 0; i < peopleList.Length; i++)
            {
                selectListItems[i].Text.Should().Be(peopleList[i].Name);
                selectListItems[i].Value.Should().Be(peopleList[i].Id.ToString());
            }

            selectListItems[2].Selected.Should().BeTrue();
        }
    }

    /// <summary>
    /// La extensión que se está utilizando espera que el tipo T sea una clase
    /// Esta clase interna sirve como placeholder para pruebas
    /// </summary>
    internal class MockPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}