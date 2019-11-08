﻿using Api.Contract;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.WebAPI.Services;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;

namespace EmpleoDotNet.WebAPI.Tests.Services
{
    [TestFixture]
    public class JobOpportunityToMobileJobAdapterTests
    {
        private IJobOpportunityToMobileJobAdapter _adapter;
        private JobCardDTO _jobCard;
        private JobOpportunity _jobOpportunity;
        private Fixture _fixture;
        private const string N_A = "N/A";

        [SetUp]
        public void SetUp()
        {
            _adapter = new JobOpportunityToMobileJobAdapter();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void GetJobCard_OpportunityLocationIsNull_JobCardPropertiesAreNotEmpty()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().Create();

            // Act
            var jobCard = _adapter.GetJobCard(_jobOpportunity);

            // Assert
            jobCard.CompanyName.Should().NotBeNullOrWhiteSpace();
            jobCard.Description.Should().NotBeNullOrWhiteSpace();
            jobCard.JobType.Should().NotBeNullOrWhiteSpace();
            jobCard.Link.Should().NotBeNullOrWhiteSpace();
            jobCard.Location.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public void GetJobCard_OpportunityLocationIsNull_JobCardLocationIsNA()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().With(x => x.Location, null).Create();

            // Act
            var jobCard = _adapter.GetJobCard(_jobOpportunity);

            // Assert
            jobCard.Location.Should().Be(N_A);
        }

        [Test]
        public void GetJobCard_OpportunityLocationIsNull_JobCardLocationIsNotNA()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().Create();

            // Act
            var jobCard = _adapter.GetJobCard(_jobOpportunity);

            // Assert
            jobCard.Should().NotBe(N_A);
        }

        [Test]
        public void GetJobDetails_OpportunityLocationIsNull_JobDetailsPropertiesAreNotEmpty()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().Create();

            // Act
            var jobDetails = _adapter.GetJobDetails(_jobOpportunity);

            // Assert
            jobDetails.Company.Email.Should().NotBeNullOrWhiteSpace();
            jobDetails.Company.Name.Should().NotBeNullOrWhiteSpace();
            jobDetails.JobDescription.Should().NotBeNullOrWhiteSpace();
            jobDetails.JobTitle.Should().NotBeNullOrWhiteSpace();
            jobDetails.JobType.Should().NotBeNullOrWhiteSpace();
            jobDetails.Link.Should().NotBeNullOrWhiteSpace();
            jobDetails.Location.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public void GetJobDetails_OpportunityLocationIsNull_JobDetailsLocationIsNA()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().With(x => x.Location, null).Create();

            // Act
            var jobDetails = _adapter.GetJobDetails(_jobOpportunity);

            // Assert
            jobDetails.Location.Should().Be(N_A);
        }

        [Test]
        public void GetJobDetails_OpportunityLocationIsNull_JobDetailsLocationIsNotNA()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().Create();

            // Act
            var jobDetails = _adapter.GetJobCard(_jobOpportunity);

            // Assert
            jobDetails.Should().NotBe(N_A);
        }
    }
}