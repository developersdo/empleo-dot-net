using System;
using System.Web;
using EmpleoDotNet.Code;
using EmpleoDotNet.Core;
using EmpleoDotNet.Helpers;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace EmpleoDotNet.Tests.Web.Helpers
{
    [TestFixture]
    public class CookieHelperTest
    {
        private HttpContextBase _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<HttpContextBase>();
            var request = Substitute.For<HttpRequestBase>();
            var response = Substitute.For<HttpResponseBase>();
            var server = Substitute.For<HttpServerUtilityBase>();

            request.Cookies.Returns(new HttpCookieCollection());
            response.Cookies.Returns(new HttpCookieCollection());
            server.HtmlEncode("").ReturnsForAnyArgs(x => x.Arg<string>());

            _context.Request.Returns(request);
            _context.Response.Returns(response);
            _context.Server.Returns(server);

            EmpleoDotNetHttpContext.Current = () => _context;
        }

        [Test]
        public void Set_SetsValueCorrectly()
        {
            // Act
            CookieHelper.Set("myKey", "myValue");

            // Assert
            var cookie = _context.Response.Cookies["myKey"];
            cookie.Name.Should().Be("myKey");
            cookie.Value.Should().Be("myValue");
        }

        [Test]
        public void Get_CookieDoesNotExist_ReturnsEmptyString()
        {
            // Act
            var value = CookieHelper.Get("myValue");

            // Assert
            value.Should().BeEmpty();
        }

        [Test]
        public void Get_CookieExists_ReturnsValue()
        {
            // Arrange
            _context.Request.Cookies.Add(new HttpCookie("myKey") { Value = "myValue" });

            // Act
            var value = CookieHelper.Get("myKey");

            // Assert
            value.Should().Be("myValue");
        }

        [Test]
        public void Exists_CookieDoesNotExist_ReturnsFalse()
        {
            // Act
            var exists = CookieHelper.Exists("myKey");

            // Assert
            exists.Should().BeFalse();
        }

        [Test]
        public void Exists_CookieExists_ReturnsTrue()
        {
            // Arrange
            _context.Request.Cookies.Add(new HttpCookie("myKey") { Value = "myValue" });

            // Act
            var exists = CookieHelper.Exists("myKey");

            // Assert
            exists.Should().BeTrue();
        }

        [Test]
        public void Delete_CookieDoesNotExistOnRequest_DoesNothing()
        {
            // Act
            CookieHelper.Delete("myKey");

            // Assert
            _context.Response.Cookies["myKey"].Should().BeNull();
        }

        [Test]
        public void Delete_CookieExistsOnRequest_ReaddsCookieToResponse_WithExpirationDateSetToYesterday()
        {
            // Arrange
            _context.Request.Cookies.Add(new HttpCookie("myKey") { Value = "myValue" });

            // Act
            CookieHelper.Delete("myKey");

            // Assert
            var cookie = _context.Response.Cookies["myKey"];
            cookie.Expires.Should().BeCloseTo(DateTime.Now.AddDays(-1));
        }
    }
}