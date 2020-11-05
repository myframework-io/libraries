using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Resultado de validadores do tipo class.
    /// </summary>
    public class ValidatorClassResult<T> : BaseValidatorResult
        where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalValue"></param>
        public ValidatorClassResult(T originalValue) => OriginalValue = originalValue;

        /// <summary>
        /// Valor original que está sendo validado.
        /// </summary>
        public T OriginalValue { get; set; }

        /// <summary>
        /// Adiciona um validador ao resultado.
        /// </summary>
        /// <param name="validator"></param>
        /// <returns></returns>
        public ValidatorClassResult<T> AddValidator(IValidator validator)
        {
            AddValidatorBase(validator);
            return this;
        }

        /// <summary>
        /// Agrega diversos resultados de validação em apenas um.
        /// </summary>
        public ValidatorClassResult<T> Aggregate(List<ValidatorClassResult<T>> results)
        {
            var baseList = results?.Select(it => it as IValidatorResult).ToList();
            AggregateBase(baseList);
            return this;
        }

        /// <summary>
        /// Agrega um ou mais resultados de validação em apenas um.
        /// </summary>
        public ValidatorClassResult<T> Aggregate(params ValidatorClassResult<T>[] results) => Aggregate(results.ToList());
    }
}