using System;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Controllers;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using EmpleoDotNet.Helpers;
using EmpleoDotNet.Helpers.Alerts;
using EmpleoDotNet.Services.Social.Twitter;
using EmpleoDotNet.ViewModel;
using EmpleoDotNet.ViewModel.JobOpportunity;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using PagedList;
using reCAPTCHA.MVC;

// ReSharper disable Mvc.ActionNotResolved
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
            _sut = new JobOpportunityController(_jobOpportunityService,null, _twitterService);
        }

        #region Index
        [Test]
        public void Index_LocationNameNotNull_PlaceIdNull_ReturnsViewWithError()
        {
            // Arrange
            var param = new JobOpportunityPagingParameter {
                SelectedLocationPlaceId = null,
                SelectedLocationName = "Guachupita",
                JobCategory = JobCategory.None,
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

            result.AlertClass.Should().Be("alert-danger");
            result.Message.Should().Be("Debe seleccionar una Localidad para buscar.");
            var viewResult = (ViewResult)result.InnerResult;
            var model = (JobOpportunitySearchViewModel)viewResult.Model;

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
                JobCategory = JobCategory.None,
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

            var model = (JobOpportunitySearchViewModel)result.Model;
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
                JobCategory = JobCategory.None,
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

            var model = (JobOpportunitySearchViewModel)result.Model;
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

        #region New

        [Test]
        public void New_GET_HasExpectedActionFilters()
        {
            // Arrange
            var controller = typeof(JobOpportunityController);
            var action = controller.GetMethod(nameof(JobOpportunityController.New),
                new Type[0]);

            // Act
            var filters = action.GetCustomAttributes().ToArray();

            // Assert
            filters.Should().ContainSingle(x => x is HttpGetAttribute);
        }

        [Test]
        public void New_GET_ReturnsView_WithEmptyModel()
        {
            // Arrange
            var model = new NewJobOpportunityViewModel();
            _sut.Url = Substitute.For<UrlHelper>();
            _sut.Url.Action("Wizard").Returns("/jobs/wizard");

            // Act
            var result = (AlertDecoratorResult)_sut.New();

            // Assert
            result.AlertClass.Should().Be("alert-warning");
            result.Message.Should().Be(
                "Prueba nuestro nuevo proceso guiado de creación de posiciones haciendo "
                + "<b><a href='/jobs/wizard'>click aquí</a></b>");

            var viewResult = (ViewResult)result.InnerResult;
            viewResult.ViewName.Should().BeEmpty();
            ((NewJobOpportunityViewModel)viewResult.Model).ShouldBeEquivalentTo(model);
        }

        [Test]
        public void New_POST_HasExpectedActionFilters()
        {
            // Arrange
            var controller = typeof(JobOpportunityController);
            var action = controller.GetMethod(nameof(JobOpportunityController.New),
                new[] { typeof(NewJobOpportunityViewModel), typeof(bool) });

            // Act
            var filters = action.GetCustomAttributes().ToArray();

            // Assert
            filters.Should().ContainSingle(x => x is HttpPostAttribute);
            filters.Should().ContainSingle(x => x is ValidateAntiForgeryTokenAttribute);

            var validateInput = (ValidateInputAttribute)filters.Single(x => x is ValidateInputAttribute);
            var captchaValidator = (CaptchaValidatorAttribute)filters.Single(x => x is CaptchaValidatorAttribute);

            validateInput.EnableValidation.Should().BeFalse();
            captchaValidator.RequiredMessage.Should().Be("Por favor confirma que no eres un robot");
        }

        [Test]
        public async Task New_POST_ModelStateInvalid_ReturnsViewWithError()
        {
            // Arrange
            var model = new NewJobOpportunityViewModel();
            
            _sut.ModelState.AddModelError("", "");

            // Act
            var result = (AlertDecoratorResult)await _sut.New(model, false);
            // Assert
            _jobOpportunityService.DidNotReceiveWithAnyArgs().CreateNewJobOpportunity(null, string.Empty);
            await _twitterService.DidNotReceiveWithAnyArgs().PostNewJobOpportunity(null, _sut.Url);

            _sut.ModelState.IsValid.Should().BeFalse();

            result.AlertClass.Should().Be("alert-danger");
            result.Message.Should().Be("Han ocurrido errores de validación que no permiten continuar el proceso");

            var innerResult = (ViewResult)result.InnerResult;
            innerResult.ViewName.Should().BeEmpty();
            innerResult.Model.Should().BeSameAs(model);
        }

        [Test]
        public async Task New_POST_LocationPlaceIdNullOrWhitespace_ReturnsViewWithError(
            [Values(null, "", " ")] string placeId
            )
        {
            // Arrange
            var model = new NewJobOpportunityViewModel { LocationPlaceId = placeId };

            // Act
            var result = (AlertDecoratorResult)await _sut.New(model, false);

            // Assert
            _jobOpportunityService.DidNotReceiveWithAnyArgs().CreateNewJobOpportunity(null,string.Empty);
            await _twitterService.DidNotReceiveWithAnyArgs().PostNewJobOpportunity(null, _sut.Url);

            _sut.ModelState.IsValid.Should().BeFalse();
            _sut.ModelState.Should().ContainKey(nameof(model.LocationName));

            result.AlertClass.Should().Be("alert-danger");
            result.Message.Should().Be("Debe seleccionar una Localidad.");

            var innerResult = (ViewResult)result.InnerResult;
            innerResult.ViewName.Should().BeEmpty();
            innerResult.Model.Should().BeSameAs(model);
        }

        [Test]
        public async Task New_POST_ValidModel_CreatesJob_PostsTweet_RedirectsToDetail()
        {
            // Arrange
            var model = new NewJobOpportunityViewModel {
                Title = "myTitle",
                Category = JobCategory.MobileDevelopment,
                Description = "My description",
                CompanyName = "Company",
                CompanyUrl = "http://example.com",
                CompanyLogoUrl = "http://s22.postimg.org/ogi7669wh/batman.png",
                CompanyEmail = "company@example.com",
                IsRemote = true,
                LocationName = "My location",
                LocationPlaceId = "123",
                LocationLatitude = "18.3939393",
                LocationLongitude = "-69.22222",
                JobType = JobType.FullTime
            };
            _sut.ControllerContext = GenerateControllerContext(_sut);
            _jobOpportunityService.WhenForAnyArgs(x => x.CreateNewJobOpportunity(null, null))
                .Do(x => { x.Arg<JobOpportunity>().Id = 1; });

            // Act
            var result = (RedirectToRouteResult)await _sut.New(model, false);

            // Assert
            _jobOpportunityService.Received(1).CreateNewJobOpportunity(
                Arg.Do<JobOpportunity>(entity => VerifyGeneratedJobOpportunityEntity(model, entity)), null);
            await _twitterService.Received(1).PostNewJobOpportunity(
                Arg.Do<JobOpportunity>(entity => VerifyGeneratedJobOpportunityEntity(model, entity)), _sut.Url);

            result.RouteValues["action"].Should().Be(nameof(_sut.Detail));
            result.RouteValues["id"].Should().Be(UrlHelperExtensions.SeoUrl(1, "myTitle"));
        }

        private ControllerContext GenerateControllerContext(ControllerBase controller)
        {
            var fakeIdentity = new GenericIdentity("Jimmy");
            var fakeUser = new GenericPrincipal(fakeIdentity, null);
            var httpContext = new Moq.Mock<HttpContextBase>();
            httpContext.Setup(x => x.User).Returns(fakeUser);
            var reqContext = new RequestContext(httpContext.Object, new RouteData());
            return new ControllerContext(reqContext, controller);
        }

        private static void VerifyGeneratedJobOpportunityEntity(
            NewJobOpportunityViewModel model,
            JobOpportunity entity)
        {
            entity.Title.Should().Be(model.Title);
            entity.Category.Should().Be(model.Category);
            entity.Description.Should().Be(model.Description);
            entity.CompanyName.Should().Be(model.CompanyName);
            entity.CompanyUrl.Should().Be(model.CompanyUrl);
            entity.CompanyLogoUrl.Should().Be(model.CompanyLogoUrl);
            entity.CompanyEmail.Should().Be(model.CompanyEmail);
            entity.PublishedDate.Should().BeCloseTo(DateTime.Now);
            entity.IsRemote.Should().Be(model.IsRemote);
            entity.JobType.Should().Be(model.JobType);
            entity.JobOpportunityLocation.Should().Match<JobOpportunityLocation>(x =>
                x.Latitude == model.LocationLatitude
                && x.Longitude == model.LocationLongitude
                && x.Name == model.LocationName
                && x.PlaceId == model.LocationPlaceId
                );
        }

        #endregion

        #region Wizard

        [Test]
        public void Wizard_GET_HasExpectedActionFilters()
        {
            // Arrange
            var controller = typeof(JobOpportunityController);
            var action = controller.GetMethod(nameof(JobOpportunityController.Wizard),
                new Type[0]);

            // Act
            var filters = action.GetCustomAttributes().ToArray();

            // Assert
            filters.Should().ContainSingle(x => x is HttpGetAttribute);
        }

        [Test]
        public void Wizard_GET_ReturnsView()
        {
            // Act
            var result = (ViewResult)_sut.Wizard();

            // Assert
            result.ViewName.Should().BeEmpty();
            ((Wizard) result.Model).ShouldBeEquivalentTo(new Wizard());
        }

        #endregion
    }
}
