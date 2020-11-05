using Myframework.Libraries.Common.Results;

namespace UnitTests.Test.Entities.BaseEntityTests
{
    public class CorrectEntitySample
    {
        private CorrectEntitySample() { }

        public int Prop1 { get; private set; }
        public int Prop2 { get; protected set; }
        public int Prop3 { get; protected internal set; }

        internal int Prop4 { get; set; }
        internal int Prop5 { get; private set; }

        protected internal int Prop6 { get; set; }
        protected internal int Prop7 { get; private set; }
        protected internal int Prop8 { get; protected set; }
        protected internal int Prop9 { get; internal set; }

        public static Result<CorrectEntitySample> Create() => new Result<CorrectEntitySample>();
    }
}