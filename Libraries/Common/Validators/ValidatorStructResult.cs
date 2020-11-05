using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Resultado de validadores do tipo struct.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidatorStructResult<T> : BaseValidatorResult
        where T : struct
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalValue"></param>
        public ValidatorStructResult(T? originalValue) => OriginalValue = originalValue;

        /// <summary>
        /// Valor original que está sendo validado.
        /// </summary>
        public T? OriginalValue { get; set; }

        /// <summary>
        /// Adiciona um validador ao resultado.
        /// </summary>
        /// <param name="validator"></param>
        /// <returns></returns>
        public ValidatorStructResult<T> AddValidator(IValidator validator)
        {
            AddValidatorBase(validator);
            return this;
        }

        /// <summary>
        /// Agrega diversos resultados de validação em apenas um.
        /// </summary>
        public ValidatorStructResult<T> Aggregate(List<ValidatorStructResult<T>> results)
        {
            var baseList = results?.Select(it => it as IValidatorResult).ToList();
            AggregateBase(baseList);
            return this;
        }

        /// <summary>
        /// Agrega um ou mais resultados de validação em apenas um.
        /// </summary>
        public ValidatorStructResult<T> Aggregate(params ValidatorStructResult<T>[] results) => Aggregate(results.ToList());
    }
}