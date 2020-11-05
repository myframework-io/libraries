using Xunit;

namespace Myframework.Libraries.Domain.SeedWork
{
    public class EnumerationTest
    {
        [Fact(DisplayName = "GetAll")]
        public void GetAll()
        {
            System.Collections.Generic.List<EnumTest> enuns = EnumTest.GetAll<EnumTest>();

            Assert.Same(EnumTest.Item1, enuns[0]);
            Assert.Same(EnumTest.Item2, enuns[1]);
            Assert.Same(EnumTest.Item3, enuns[2]);

            // Obtendo novamente, mas com os itens já em memória
            enuns = EnumTest.GetAll<EnumTest>();

            Assert.Same(EnumTest.Item1, enuns[0]);
            Assert.Same(EnumTest.Item2, enuns[1]);
            Assert.Same(EnumTest.Item3, enuns[2]);
        }

        [Fact(DisplayName = "ToString")]
        public void ToStringTest() => Assert.Equal("Item 1", EnumTest.Item1.ToString());

        [Fact(DisplayName = "FromId")]
        public void FromId()
        {
            Assert.Same(EnumTest.Item1, EnumTest.FromId<EnumTest>(0));
            Assert.Same(EnumTest.Item2, EnumTest.FromId<EnumTest>(1));
            Assert.Same(EnumTest.Item3, EnumTest.FromId<EnumTest>(2));
        }

        [Fact(DisplayName = "FromName")]
        public void FromName()
        {
            Assert.Same(EnumTest.Item1, EnumTest.FromName<EnumTest>("Item 1"));
            Assert.Same(EnumTest.Item2, EnumTest.FromName<EnumTest>("Item 2"));
            Assert.Same(EnumTest.Item3, EnumTest.FromName<EnumTest>("Item 3"));
        }


        /// <summary>
        /// 
        /// </summary>
        public class EnumTest : Enumeration<byte>
        {
            public EnumTest() { }

            public EnumTest(byte id, string name) : base(id, name) { }

            public static readonly EnumTest Item1 = new EnumTest(0, "Item 1");
            public static readonly EnumTest Item2 = new EnumTest(1, "Item 2");
            public static readonly EnumTest Item3 = new EnumTest(2, "Item 3");
        }

    }
}