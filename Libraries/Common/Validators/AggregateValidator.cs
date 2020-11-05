using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Agregador de validadores. Permite juntar diversos validadores em um só.
    /// </summary>
    public class AggregateValidator : BaseValidatorResult
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="results"></param>
        public AggregateValidator(List<IValidatorResult> results) => Aggregate(results);

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="results"></param>
        public AggregateValidator(params IValidatorResult[] results) => Aggregate(results);

        /// <summary>
        /// Agrega diversos validadores.
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public AggregateValidator Aggregate(List<IValidatorResult> results)
        {
            AggregateBase(results);
            return this;
        }

        /// <summary>Agrega um ou mais resultados de validação em apenas um.</summary>
        public AggregateValidator Aggregate(params IValidatorResult[] results) => Aggregate(results.ToList());
    }
}