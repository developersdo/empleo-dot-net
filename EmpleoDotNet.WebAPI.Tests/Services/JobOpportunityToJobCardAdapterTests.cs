using Api.Contract;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.WebAPI.Services;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Linq;

namespace EmpleoDotNet.WebAPI.Tests.Services
{
    [TestFixture]
    public class JobOpportunityToJobCardAdapterTests
    {
        private IJobOpportunityToJobCardAdapter _adapter;
        private JobCardDTO _jobCard;
        private JobOpportunity _jobOpportunity;
        private Fixture _fixture;
        private const string N_A = "N/A";

        [SetUp]
        public void SetUp()
        {
            _adapter = new JobOpportunityToJobCardAdapter();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void Convert_OpportunityLocationIsNull_JobCardPropertiesAraNotEmpty()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().Create();

            // Act
            var jobCard = _adapter.Convert(_jobOpportunity);

            // Assert
            jobCard.CompanyName.Should().NotBeNullOrWhiteSpace();
            jobCard.Job.Should().NotBeNullOrWhiteSpace();
            jobCard.JobType.Should().NotBeNullOrWhiteSpace();
            jobCard.Link.Should().NotBeNullOrWhiteSpace();
            jobCard.Location.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public void Convert_OpportunityLocationIsNull_JobCardLocationIsNA()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().With(x => x.Location, null).Create();

            // Act
            var jobCard = _adapter.Convert(_jobOpportunity);

            // Assert
            jobCard.Location.Should().Be(N_A);
        }

        [Test]
        public void Convert_OpportunityLocationIsNull_JobCardLocationIsNotNA()
        {
            // Arrange
            _jobOpportunity = _fixture.Build<JobOpportunity>().Create();

            // Act
            var jobCard = _adapter.Convert(_jobOpportunity);

            // Assert
            jobCard.Should().NotBe(N_A);
        }
    }
}