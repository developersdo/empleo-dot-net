using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.Controllers;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.ViewModel;
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
            List<JobOpportunity> expectedModel = new[] {
                new JobOpportunity { Id = 123 }
            }.ToList();

            _jobOpportunityRepository.GetLatestJobOpportunity(7)
                .Returns(expectedModel);

            // Act
            var result = (ViewResult)_sut.Index();

            // Assert
            _jobOpportunityRepository.Received(1).GetLatestJobOpportunity(7);

            var viewModel = (List<JobOpportunity>)result.Model;
            viewModel.Should().BeSameAs(expectedModel);
        }

        [Test]
        public void Index_PopulatesViewBagSearchModelCorrectly()
        {
            // Arrange
            var expectedSearchModel = new[] {
                    new JobCategoryCountDto()
                }.ToList();

            _jobOpportunityRepository.GetMainJobCategoriesCount()
                .Returns(expectedSearchModel);

            // Act
            var result = (ViewResult)_sut.Index();

            // Assert
            _jobOpportunityRepository.Received(1).GetMainJobCategoriesCount();

            var searchModel = (JobOpportunitySearchViewModel)result.ViewBag.SearchViewModel;
            searchModel.CategoriesCount.Should().BeSameAs(expectedSearchModel);
        }
    }
}
