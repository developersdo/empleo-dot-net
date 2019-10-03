using System;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Controllers;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Services.Social.Twitter;
using FluentAssertions;
using Moq;
using NSubstitute;
using NUnit.Framework;

namespace EmpleoDotNet.Tests.Services.Twitter
{
    [TestFixture]
    public class TwitterServiceTests
    {
        private ITwitterService _sut;
        private IJobOpportunityService _jobOpportunityService;
        private JobOpportunityController _jobOpportunityController;

        [SetUp]
        public void SetUp()
        {
            _sut = new TwitterService();
            _jobOpportunityService = Substitute.For<IJobOpportunityService>();
            _jobOpportunityController = new JobOpportunityController(_jobOpportunityService,null, _sut);
        }
 
        [Test]
        public void Should_Send_Tweet()
        {
            //Arrange
            const string message = "Hello Twitter!!";

            //Act
            Action act = () => _sut.PostTweet(message).Wait();

            //Assert
            act.ShouldNotThrow();
        }

        [Test]
        public void Should_Tweet_JobOpportunity_With_80_Title_Chars()
        {
            //Arrange
            _jobOpportunityController.Url = new UrlHelper(new RequestContext(MvcMoqHelpers.FakeHttpContext(), new RouteData()));
            var title = Get80CharsTitle();

            var jobOpportunity = new JobOpportunity
            {
                Title = title,
                Id = 1
            };
            //Act
            Action act = () => _sut.PostNewJobOpportunity(jobOpportunity, _jobOpportunityController.Url).Wait();

            //Assert
            act.ShouldNotThrow();
        }

        [Test]
        public void Should_Tweet_Remote_JobOpportunity_With_Hashtag()
        {
            //Arrange
            _jobOpportunityController.Url = new UrlHelper(new RequestContext(MvcMoqHelpers.FakeHttpContext(), new RouteData()));

            var title = Get80CharsTitle();

            var jobOpportunity = new JobOpportunity
            {
                Id = 999999999,
                Title = title,
                IsRemote = true
            };
            //Act
            Action act = () => _sut.PostNewJobOpportunity(jobOpportunity, _jobOpportunityController.Url).Wait();

            //Assert
            act.ShouldNotThrow();
        }

        [Test]
        public void Should_Not_Tweet_Null_Message()
        {
            //Act
            Action act = () => _sut.PostTweet(null).Wait();

            //Assert
            act.ShouldNotThrow();
        }

        [Test]
        public void Should_Tweet_JobOpportunity_With_140_Chars()
        {
            //Arrange
            var title = Get80CharsTitle();
            _jobOpportunityController.Url = new UrlHelper(new RequestContext(MvcMoqHelpers.FakeHttpContext(), new RouteData()));
            var jobOpportunity = new JobOpportunity
            {
                Title = title,
                Id = 999999999
            };
            //Act
            Action act = () => _sut.PostNewJobOpportunity(jobOpportunity, _jobOpportunityController.Url).Wait();

            //Assert
            act.ShouldNotThrow();
        }

        [Test]
        public void Should_Tweet_JobOpportunity_With_More_Of_140_Chars()
        {
            //Arrange
            _jobOpportunityController.Url = new UrlHelper(new RequestContext(MvcMoqHelpers.FakeHttpContext(), new RouteData()));
            var title = Get80CharsTitle();
            title += Get80CharsTitle();

            var jobOpportunity = new JobOpportunity
            {
                Title = title,
                Id = 999999999
            };
            //Act
            Action act = () => _sut.PostNewJobOpportunity(jobOpportunity, _jobOpportunityController.Url).Wait();

            //Assert
            act.ShouldNotThrow();
        }

        private static string Get80CharsTitle()
        {
            var result = "";

            for (var i = 0; i < 80; i++)
            {
                result += "a";
            }

            return result;
        }
    }

    public static class MvcMoqHelpers
    {
        public static HttpContextBase FakeHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new Mock<HttpSessionStateBase>();
            var server = new Mock<HttpServerUtilityBase>();

            request.Setup(r => r.AppRelativeCurrentExecutionFilePath).Returns("/");
            request.Setup(r => r.ApplicationPath).Returns("/");
            response.Setup(s => s.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);

            return context.Object;
        }
    }

}