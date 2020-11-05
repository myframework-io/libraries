using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace Myframework.Libraries.Application.ModelBinders
{
    /// <summary>
    /// Provider que utiliza o model binder responsável por tratar o formato de data para a cultura atual.
    /// </summary>
    public class CurrentCultureDateTimeBinderProvider : IModelBinderProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
                return new BinderTypeModelBinder(typeof(CurrentCultureDateTimeBinder));

            return null;
        }
    }
}