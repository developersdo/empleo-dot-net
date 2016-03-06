using System.ComponentModel;
using System.Web.Mvc;

namespace EmpleoDotNet.Code
{
    public class TrimModelBinder : DefaultModelBinder
    {
        // For binding simple string parameters
        public override object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(string))
                return base.BindModel(controllerContext, bindingContext);

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var attemptedValue = value?.AttemptedValue?.Trim();

            return string.IsNullOrEmpty(attemptedValue) ? null : attemptedValue;
        }

        // For binding properties on complex model types
        protected override void SetProperty(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor,
            object value)
        {
            if (propertyDescriptor.PropertyType == typeof(string))
            {
                var stringValue = ((string)value)?.Trim();
                value = string.IsNullOrEmpty(stringValue) ? null : stringValue;
            }

            base.SetProperty(controllerContext, bindingContext,
                propertyDescriptor, value);
        }
    }
}