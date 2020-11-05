using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using System.Threading.Tasks;

namespace Myframework.Libraries.Application.ModelBinders
{
    /// <summary>
    /// Model binder responsável por tratar o formato de decimal para a cultura atual.
    /// </summary>
    public class CurrentCultureDecimalBinder : IModelBinder
    {
        /// <summary>
        /// 
        /// </summary>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueProvider = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProvider.FirstValue == null)
            {
                bindingContext.Model = null;
                return Task.CompletedTask;
            }


            if (decimal.TryParse(valueProvider.FirstValue, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal parsedValue))
            {
                bindingContext.Model = parsedValue;
                bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            }
            else
                bindingContext.Model = null;

            return Task.CompletedTask;
        }
    }
}