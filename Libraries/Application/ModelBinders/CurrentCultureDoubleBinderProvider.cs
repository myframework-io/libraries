using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace Myframework.Libraries.Application.ModelBinders
{
    /// <summary>
    /// Provider que utiliza o model binder responsável por tratar o formato de double para a cultura atual.
    /// </summary>
    public class CurrentCultureDoubleBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(double) || context.Metadata.ModelType == typeof(double?))
                return new BinderTypeModelBinder(typeof(CurrentCultureDoubleBinder));

            return null;
        }
    }
}