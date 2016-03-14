using System.Collections.Specialized;
using System.Web.Mvc;
using EmpleoDotNet.Code;
using FluentAssertions;
using NUnit.Framework;

namespace EmpleoDotNet.Tests.Web.Helpers
{
    [TestFixture]
    public class TrimModelBinderTest
    {
        [TestCaseSource(nameof(TrimModelBinderTestCases))]
        public void TrimModelBinder_TrimsStringValue(
            string inserted,
            string expected)
        {
            // Arrange
            var formCollection = new NameValueCollection
            {
                ["name"] = inserted
            };

            var valueProvider = new NameValueCollectionValueProvider(formCollection, null);
            var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(string));

            var bindingContext = new ModelBindingContext
            {
                ModelName = "name",
                ValueProvider = valueProvider,
                ModelMetadata = modelMetadata
            };

            var binder = new TrimModelBinder();
            var controllerContext = new ControllerContext();
            
            // Act
            var result = (string)binder.BindModel(controllerContext, bindingContext);

            // Assert
            result.Should().Be(expected);
        }

        [TestCaseSource(nameof(TrimModelBinderTestCases))]
        public void TrimModelBinder_TrimsStringValuesOnModel(
            string inserted,
            string expected)
        {
            // Arrange
            var formCollection = new NameValueCollection
            {
                ["model.Name"] = inserted,
            };

            var valueProvider = new NameValueCollectionValueProvider(formCollection, null);
            var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(TestUserModel));

            var bindingContext = new ModelBindingContext
            {
                ModelName = "model",
                ValueProvider = valueProvider,
                ModelMetadata = modelMetadata
            };

            var binder = new TrimModelBinder();
            var controllerContext = new ControllerContext();

            // Act
            var result = (TestUserModel)binder.BindModel(controllerContext, bindingContext);

            // Assert
            result.Name.Should().Be(expected);
        }

        private static readonly TestCaseData[] TrimModelBinderTestCases =
        {
            new TestCaseData("  Juan Perez  ", "Juan Perez").SetName("Full Trim"),
            new TestCaseData("  Juan Perez", "Juan Perez").SetName("Left Trim"),
            new TestCaseData("Juan Perez  ", "Juan Perez").SetName("Right Trim"),
            new TestCaseData("  \t \r\n", null).SetName("Whitespace-only set to null"),
            new TestCaseData(string.Empty, null).SetName("Empty string set to null"),
            new TestCaseData(null, null).SetName("Null string set to null")
        };

        private class TestUserModel
        {
            // ReSharper disable once UnusedAutoPropertyAccessor.Local
            public string Name { get; set; }
        }
    }
}
