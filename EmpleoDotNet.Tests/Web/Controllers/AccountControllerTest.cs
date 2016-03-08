using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Controllers;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.Services.Social.Twitter;
using FluentAssertions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;

namespace EmpleoDotNet.Tests.Web.Controllers
{
    [TestFixture]
    public class AccountControllerTest
    {
        private IAuthenticationService _authenticationService;
        private IUserProfileRepository _userProfileRepository;
        private IUserStore<IdentityUser> _userStore;
        private UserManager<IdentityUser> _userManager;
        private AccountController _sut;

        [SetUp]
        public void SetUp()
        {
            this._authenticationService = Substitute.For<IAuthenticationService>();
            this._userProfileRepository = Substitute.For<IUserProfileRepository>();
            this._userStore = Substitute.For<IUserStore<IdentityUser>>();
            this._userManager = Substitute.For<UserManager<IdentityUser>>(_userStore);
            _sut = new AccountController(_authenticationService, _userProfileRepository, _userManager);
            _sut.ControllerContext = GenerateControllerContext(_sut);
        }

        [Test]
        public void Login_GET_ReturnsRequestedDataCorrect_WithReturnUrl()
        {
            var redirectUrl = "/jobopportunity/new";
            var viewResult = (ViewResult)_sut.Login(redirectUrl);
            var returnUrl = (string)viewResult.ViewBag.ReturnUrl;
            returnUrl.Should().BeSameAs(redirectUrl);
        }

        [Test]
        public void Profile_GET_Without_Login_ReturnsViewWithError()
        {
            _userProfileRepository.GetByUserId(null).Returns(x=>null);
            var viewResult = (ViewResult) _sut.Profile();
            viewResult.Model.Should().BeNull();
        }

        [Test]
        public void Profile_GET_With_Login_ReturnsRequestedDataCorrect()
        {
            var fakeUserProfile = new UserProfile
            {
                Email = "hola@emplea.do",
                Name = "Juan Perez"
            };
            _userProfileRepository.GetByUserId(null).Returns(fakeUserProfile);

            var viewResult = (ViewResult)_sut.Profile();
            viewResult.Model.Should().NotBeNull();
            viewResult.Model.As<UserProfile>().Email.Should().Be(fakeUserProfile.Email);
            viewResult.Model.As<UserProfile>().Name.Should().Be(fakeUserProfile.Name);
        }

        private ControllerContext GenerateControllerContext(ControllerBase controller)
        {
            var fakeIdentity = new GenericIdentity("Jimmy");
            var fakeUser = new GenericPrincipal(fakeIdentity,null);
            var httpContext = new Moq.Mock<HttpContextBase>();
            httpContext.Setup(x => x.User).Returns(fakeUser);
            var reqContext = new RequestContext(httpContext.Object, new RouteData());
            return new ControllerContext(reqContext, controller);
        }
    }
}
