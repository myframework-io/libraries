using Myframework.Libraries.Test.Entities;
using Xunit;

namespace UnitTests.Test.Entities.BaseEntityTests
{
    public class EntityTestHelperTests
    {
        [Fact(DisplayName = "Class has only one private/protected/internal protected constructor")]
        public void CheckIfEntityHaveOnlyOnePrivateOrProtectedOrInternalProtectedConstructor() =>
            Assert.True(EntityTestHelper.CheckIfEntityHaveOnlyOnePrivateOrProtectedOrInternalProtectedConstructor<CorrectEntitySample>());

        [Fact(DisplayName = "Class has a static create method")]
        public void CheckIfEntityHaveStaticCreateMethod() =>
            Assert.True(EntityTestHelper.CheckIfEntityHaveStaticCreateMethod<CorrectEntitySample>());

        [Fact(DisplayName = "Class has public or internal properties cannot have set accessor")]
        public void CheckIfEntityPropertiesHavePublicOrInternalSetAccessor() =>
            Assert.True(EntityTestHelper.CheckIfEntityPropertiesHavePublicOrInternalSetAccessor<CorrectEntitySample>());

        [Fact(DisplayName = "Internal constructor not allowed for entities")]
        public void InternalConstructorNotAllowedForEntities() =>
            Assert.True(EntityTestHelper.CheckIfEntityHaveOnlyOnePrivateOrProtectedOrInternalProtectedConstructor<InternalConstructorEntitySample>());
    }
}