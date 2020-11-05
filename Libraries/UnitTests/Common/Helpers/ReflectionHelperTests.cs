using Myframework.Libraries.Common.Helpers;
using System.ComponentModel;
using Xunit;

namespace Common.Helpers
{
    public class ReflectionHelperTests
    {
        [Fact(DisplayName = "Get description")]
        public void GetDescription()
        {
            Assert.Null(ReflectionHelper.GetDescription<TestRelfectionClass>());
            Assert.Equal("some description 2", ReflectionHelper.GetDescription<TestRelfection2Class>());
        }

        [Theory(DisplayName = "Get property description")]
        [InlineData("Prop2", "some description 3")]
        [InlineData("Prop1", null)]
        public void GetPropertyDescription(string propertyName, string descriptionExpected)
        {
            if (descriptionExpected == null)
                Assert.Null(ReflectionHelper.GetDescription<TestRelfection2Class>(propertyName));
            else
                Assert.Equal(descriptionExpected, ReflectionHelper.GetDescription<TestRelfection2Class>(propertyName));
        }

        [Theory(DisplayName = "Get description attribute property")]
        [InlineData("Prop1", false)]
        [InlineData("Prop2", true)]
        public void GetPropertyDescriptionAttribute(string propertyName, bool assertNull)
        {
            if (assertNull)
                Assert.Null(ReflectionHelper.GetDescriptionAttribute<TestRelfectionClass>(propertyName));
            else
                Assert.NotNull(ReflectionHelper.GetDescription<TestRelfectionClass>(propertyName));
        }

        [Theory(DisplayName = "Has attribute")]
        [InlineData("Prop2", true)]
        [InlineData("Prop1", false)]
        public void HasAttribute(string propertyName, bool assertTrue)
        {
            if (assertTrue)
                Assert.True(ReflectionHelper.HasAttribute<TestRelfection2Class, DescriptionAttribute>(propertyName));
            else
                Assert.False(ReflectionHelper.HasAttribute<TestRelfection2Class, DescriptionAttribute>(propertyName));
        }

        [Theory(DisplayName = "Get attribute property")]
        [InlineData("Prop1", false)]
        [InlineData("Prop2", true)]
        public void GetPropertyAttribute(string propertyName, bool assertNull)
        {
            if (assertNull)
                Assert.Null(ReflectionHelper.GetAttribute<TestRelfectionClass, DescriptionAttribute>(propertyName));
            else
                Assert.NotNull(ReflectionHelper.GetAttribute<TestRelfectionClass, DescriptionAttribute>(propertyName));
        }

        [Fact(DisplayName = "Set property value")]
        public void SetPropertyValue()
        {
            string newProp1 = "new value 1";

            var test = new TestRelfectionClass { Prop1 = null, Prop2 = "asdsada" };

            ReflectionHelper.SetPropertyValue(test, nameof(test.Prop1), newProp1);
            ReflectionHelper.SetPropertyValue(test, nameof(test.Prop2), null);

            Assert.Equal(newProp1, test.Prop1);
            Assert.Null(test.Prop2);
        }

        [Fact(DisplayName = "Get property value")]
        public void GetPropertyValue()
        {
            var test = new TestRelfectionClass { Prop1 = null, Prop2 = "asdsada" };

            Assert.Equal(test.Prop1, ReflectionHelper.GetPropertyValue(test, nameof(test.Prop1)));
            Assert.Equal(test.Prop2, ReflectionHelper.GetPropertyValue(test, nameof(test.Prop2)));
        }

        [Fact(DisplayName = "Set private field value")]
        public void SetPrivateFieldValue()
        {
            string newValue = "new value 1";

            var test = new TestRelfectionClass { };

            ReflectionHelper.SetNonPublicField(test, "field1", newValue);
            Assert.Equal(newValue, ReflectionHelper.GetNonPublicField(test, "field1"));

            ReflectionHelper.SetNonPublicField(test, "field1", null);
            Assert.Null(ReflectionHelper.GetNonPublicField(test, "field1"));
        }

        [Fact(DisplayName = "Set protected field value")]
        public void SetProtectedFieldValue()
        {
            string newValue = "new value 1";

            var test = new TestRelfectionClass { };

            ReflectionHelper.SetNonPublicField(test, "field2", newValue);
            Assert.Equal(newValue, ReflectionHelper.GetNonPublicField(test, "field2"));

            ReflectionHelper.SetNonPublicField(test, "field2", null);
            Assert.Null(ReflectionHelper.GetNonPublicField(test, "field2"));
        }

        public class TestRelfectionClass
        {
            private readonly string field1;
            protected string field2;

            [Description("some description")]
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
        }

        [Description("some description 2")]
        public class TestRelfection2Class
        {
            public string Prop1 { get; set; }

            [Description("some description 3")]
            public string Prop2 { get; set; }
        }
    }
}