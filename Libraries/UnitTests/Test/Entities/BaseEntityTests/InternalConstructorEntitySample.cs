using Myframework.Libraries.Common.Results;

namespace UnitTests.Test.Entities.BaseEntityTests
{
    public class InternalConstructorEntitySample
    {
        internal InternalConstructorEntitySample() { }

        public int Prop1 { get; private set; }

        public static Result<CorrectEntitySample> Create() => new Result<CorrectEntitySample>();
    }
}