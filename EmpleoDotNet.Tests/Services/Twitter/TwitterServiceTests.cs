using System;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Services;
using EmpleoDotNet.Services.Social.Twitter;
using FluentAssertions;
using NUnit.Framework;

namespace EmpleoDotNet.Tests.Services.Twitter
{
    [TestFixture]
    public class TwitterServiceTests
    {
        private readonly ITwitterService _sut;

        public TwitterServiceTests()
        {
            _sut = new TwitterService(new ConfigurationManagerSettingsProvider());
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
            var title = Get80CharsTitle();

            var jobOpportunity = new JobOpportunity
            {
                Title = title,
                Id = 1
            };

            //Act
            Action act = () => _sut.PostNewJobOpportunity(jobOpportunity).Wait();

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

            var jobOpportunity = new JobOpportunity
            {
                Title = title,
                Id = 999999999
            };

            //Act
            Action act = () => _sut.PostNewJobOpportunity(jobOpportunity).Wait();

            //Assert
            act.ShouldNotThrow();
        }

        [Test]
        public void Should_Tweet_JobOpportunity_With_More_Of_140_Chars()
        {
            //Arrange
            var title = Get80CharsTitle();
            title += Get80CharsTitle();

            var jobOpportunity = new JobOpportunity
            {
                Title = title,
                Id = 999999999
            };

            //Act
            Action act = () => _sut.PostNewJobOpportunity(jobOpportunity).Wait();

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
}