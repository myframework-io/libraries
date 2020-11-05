using Myframework.Libraries.Common.Validators;
using Myframework.Libraries.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Common.Validators
{
    public class MustValidatorTest : BaseValidatorTest
    {
        [Fact(DisplayName = "Must enumeration valid")]
        public void MustEnumerationValid()
        {
            Status status = Status.Status1;
            AssertValidResult(status.Must(() => status != null && Status.GetAll<Status>().Any(it => it.Id == status.Id), "Invalid enumeration."));
        }

        [Fact(DisplayName = "Must enumeration invalid: new enumeration")]
        public void MustEnumerationInvalid()
        {
            var status = new Status(99, "Test");
            string msg = "Invalid enumeration.";
            AssertInvalidResult(status.Must(() => status != null && Status.GetAll<Status>().Any(it => it.Id == status.Id), msg), msg);
        }

        [Fact(DisplayName = "Must enumeration invalid: null")]
        public void MustEnumerationInvalidNull()
        {
            Status status = null;
            string msg = "Invalid enumeration.";
            AssertInvalidResult(status.Must(() => status != null && Status.GetAll<Status>().Any(it => it.Id == status.Id), msg), msg);
        }

        public class Status : Enumeration<byte>
        {
            private static List<Status> allItens;

            public Status() { }

            public Status(byte id, string name) : base(id, name) { }

            public static List<Status> GetAll()
            {
                if (allItens == null)
                    allItens = GetAll<Status>();

                return allItens;
            }

            public static readonly Status Status1 = new Status(1, "Status 1");
            public static readonly Status Status2 = new Status(2, "Status 2");
            public static readonly Status Status3 = new Status(3, "Status 3");
        }
    }
}