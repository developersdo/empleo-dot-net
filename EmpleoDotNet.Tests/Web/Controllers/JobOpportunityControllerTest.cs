using System.Linq;
using System.Web.Mvc;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Controllers;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Helpers.Alerts;
using EmpleoDotNet.Services.Social.Twitter;
using EmpleoDotNet.ViewModel;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PagedList;

namespace EmpleoDotNet.Tests.Web.Controllers
{
    [TestFixture]
    public class JobOpportunityControllerTest
    {
        private IJobOpportunityService _jobOpportunityService;
        private ITwitterService _twitterService;
        private JobOpportunityController _sut;

        [SetUp]
        public void SetUp()
        {
            _jobOpportunityService = Substitute.For<IJobOpportunityService>();
            _twitterService = Substitute.For<ITwitterService>();
            _sut = new JobOpportunityController(_jobOpportunityService, _twitterService);
        }

        #region Index
        [Test]
        public void Index_LocationNameNotNull_PlaceIdNull_ReturnsViewWithError()
        {
            // Arrange
            var param = new JobOpportunityPagingParameter {
                SelectedLocationPlaceId = null,
                SelectedLocationName = "Guachupita",
                JobCategory = JobCategory.All,
                Keyword = "myKeyword",
                IsRemote = true
            };

            var jobCategoriesCount = new[] { new JobCategoryCountDto() }.ToList();
            _jobOpportunityService.GetMainJobCategoriesCount().Returns(jobCategoriesCount);

            // Act
            var result = (AlertDecoratorResult)_sut.Index(param);

            // Assert
            _jobOpportunityService.Received(1).GetMainJobCategoriesCount();
            _jobOpportunityService.DidNotReceiveWithAnyArgs().GetAllJobOpportunitiesPagedByFilters(param);

            _sut.ModelState.IsValid.Should().BeFalse();
            _sut.ModelState.Should().ContainKey("SelectedLocationName");

            result.Message.Should().Be("Debe seleccionar una Localidad para buscar.");
            var viewResult = (ViewResult)result.InnerResult;
            var model = (ViewModel.JobOpportunity.SearchViewModel)viewResult.Model;

            model.SelectedLocationLatitude.Should().Be(param.SelectedLocationLatitude);
            model.SelectedLocationLongitude.Should().Be(param.SelectedLocationLongitude);
            model.SelectedLocationPlaceId.Should().BeNull();
            model.SelectedLocationName.Should().Be(param.SelectedLocationName);
            model.JobCategory.Should().Be(param.JobCategory);
            model.Keyword.Should().Be(param.Keyword);
            model.IsRemote.Should().Be(param.IsRemote);
            model.CategoriesCount.Should().BeSameAs(jobCategoriesCount);
            model.Result.Should().BeEmpty();
        }

        [Test]
        public void Index_ReturnsRequestedDataCorrectly_LocationEmpty()
        {
            // Arrange
            var param = new JobOpportunityPagingParameter {
                SelectedLocationName = string.Empty,
                SelectedLocationLatitude = "18.686868",
                SelectedLocationLongitude = "-69.454545",
                SelectedLocationPlaceId = "111",
                JobCategory = JobCategory.All,
                Keyword = "myKeyword",
                IsRemote = true
            };

            var jobCategoriesCount = new[] { new JobCategoryCountDto() }.ToList();
            var jobOpportunityList = new[] { new JobOpportunity() }.ToPagedList(1, 1);

            _jobOpportunityService.GetMainJobCategoriesCount().Returns(jobCategoriesCount);
            _jobOpportunityService.GetAllJobOpportunitiesPagedByFilters(param).Returns(jobOpportunityList);

            // Act
            var result = (ViewResult)_sut.Index(param);

            // Assert
            _sut.ModelState.IsValid.Should().BeTrue();

            _jobOpportunityService.Received(1).GetMainJobCategoriesCount();
            _jobOpportunityService.Received(1).GetAllJobOpportunitiesPagedByFilters(param);

            var model = (ViewModel.JobOpportunity.SearchViewModel)result.Model;
            model.SelectedLocationLatitude.Should().BeEmpty();
            model.SelectedLocationLongitude.Should().BeEmpty();
            model.SelectedLocationPlaceId.Should().BeEmpty();
            model.SelectedLocationName.Should().BeEmpty();
            model.JobCategory.Should().Be(param.JobCategory);
            model.Keyword.Should().Be(param.Keyword);
            model.IsRemote.Should().Be(param.IsRemote);
            model.CategoriesCount.Should().BeSameAs(jobCategoriesCount);
            model.Result.Should().BeSameAs(jobOpportunityList);
        }

        [Test]
        public void Index_ReturnsRequestedDataCorrectly_LocationNotEmpty()
        {
            // Arrange
            var param = new JobOpportunityPagingParameter {
                SelectedLocationName = "Santo Domingo",
                SelectedLocationLatitude = "18.686868",
                SelectedLocationLongitude = "-69.454545",
                SelectedLocationPlaceId = "111",
                JobCategory = JobCategory.All,
                Keyword = "myKeyword",
                IsRemote = true
            };

            var jobCategoriesCount = new[] { new JobCategoryCountDto() }.ToList();
            var jobOpportunityList = new[] { new JobOpportunity() }.ToPagedList(1, 1);

            _jobOpportunityService.GetMainJobCategoriesCount().Returns(jobCategoriesCount);
            _jobOpportunityService.GetAllJobOpportunitiesPagedByFilters(param).Returns(jobOpportunityList);

            // Act
            var result = (ViewResult)_sut.Index(param);

            // Assert
            _sut.ModelState.IsValid.Should().BeTrue();

            _jobOpportunityService.Received(1).GetMainJobCategoriesCount();
            _jobOpportunityService.Received(1).GetAllJobOpportunitiesPagedByFilters(param);

            var model = (ViewModel.JobOpportunity.SearchViewModel)result.Model;
            model.SelectedLocationLatitude.Should().Be(param.SelectedLocationLatitude);
            model.SelectedLocationLongitude.Should().Be(param.SelectedLocationLongitude);
            model.SelectedLocationPlaceId.Should().Be(param.SelectedLocationPlaceId);
            model.SelectedLocationName.Should().Be(param.SelectedLocationName);
            model.JobCategory.Should().Be(param.JobCategory);
            model.Keyword.Should().Be(param.Keyword);
            model.IsRemote.Should().Be(param.IsRemote);
            model.CategoriesCount.Should().BeSameAs(jobCategoriesCount);
            model.Result.Should().BeSameAs(jobOpportunityList);
        }
        #endregion
    }
}
