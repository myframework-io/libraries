using Xunit;

namespace Myframework.Libraries.Test.Entities
{
    /// <summary>
    /// Classe com testes padrões de entidades.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseEntityTest<TEntity>
    {
        [Fact(DisplayName = "Entity default validation: must have only one private/protected/internal protected constructor")]
        public void MustHaveOnlyOnePrivateProtectedInternalProtectedConstructorFact() =>
            Assert.True(EntityTestHelper.CheckIfEntityHaveOnlyOnePrivateOrProtectedOrInternalProtectedConstructor<TEntity>());

        [Fact(DisplayName = "Entity default validation: must have a static create method")]
        public void MustHaveStaticCreateMethodFact() =>
            Assert.True(EntityTestHelper.CheckIfEntityHaveStaticCreateMethod<TEntity>());

        [Fact(DisplayName = "Entity default validation: public or internal properties cannot have set accessor")]
        public void PublicOrInternalPropertiesCannotHaveSetAccessorFact() =>
            Assert.True(EntityTestHelper.CheckIfEntityPropertiesHavePublicOrInternalSetAccessor<TEntity>());
    }
}