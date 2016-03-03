using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Controllers;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.ViewModel;
using EmpleoDotNet.ViewModel.Home;
using EmpleoDotNet.ViewModel.JobOpportunity;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace EmpleoDotNet.Tests.Web.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IJobOpportunityRepository _jobOpportunityRepository;
        private HomeController _sut;

        [SetUp]
        public void Init()
        {
            _jobOpportunityRepository = Substitute.For<IJobOpportunityRepository>();
            _sut = new HomeController(_jobOpportunityRepository);
        }

        [Test]
        public void Index_ReturnsModelCorrectly()
        {
            // Arrange
            var latestJobs = new[] { new JobOpportunity {Id = 123} }.ToList();
            var expectedJobCategoriesCount = new[] { new JobCategoryCountDto() }.ToList();
            _jobOpportunityRepository.GetMainJobCategoriesCount().Returns(expectedJobCategoriesCount);
            _jobOpportunityRepository.GetLatestJobOpportunity(7).Returns(latestJobs);

            var expectedModel = new HomeIndexViewModel
            {
                LatestJobs = latestJobs,
                SearchViewModel = new JobOpportunitySearchViewModel
                {
                    CategoriesCount = expectedJobCategoriesCount
                }
            };

            // Act
            var result = (ViewResult)_sut.Index();

            // Assert
            _jobOpportunityRepository.Received(1).GetLatestJobOpportunity(7);

            var viewModel = (HomeIndexViewModel)result.Model;
            viewModel.SearchViewModel.CategoriesCount.Should().Equal(expectedModel.SearchViewModel.CategoriesCount);
            viewModel.LatestJobs.Should().BeSameAs(expectedModel.LatestJobs);
        }
    }
}
