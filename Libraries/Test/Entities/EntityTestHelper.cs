using Myframework.Libraries.Common.Results;
using System.Linq;
using System.Reflection;

namespace Myframework.Libraries.Test.Entities
{
    /// <summary>
    /// Classe com métodos úteis para testes de entidades.
    /// </summary>
    public static class EntityTestHelper
    {
        /// <summary>
        /// Verifica se a entidade tem um único construtor e que ele não seja aberto.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static bool CheckIfEntityHaveOnlyOnePrivateOrProtectedOrInternalProtectedConstructor<TEntity>()
        {
            ConstructorInfo[] constuctors = typeof(TEntity).GetConstructors();
            return (constuctors == null || !constuctors.Any());
        }

        /// <summary>
        /// Verifica se uma entidade possui um método estático para criação, retornando um result da entidade em questão.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static bool CheckIfEntityHaveStaticCreateMethod<TEntity>()
        {
            MethodInfo method = typeof(TEntity).GetMethod("Create", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            return
                method != null
                && method.IsStatic
                && (method.IsPublic || method.IsAssembly)
                && typeof(Result) == method.ReturnType.BaseType
                && method.ReturnType.GenericTypeArguments.Any()
                && typeof(TEntity) == method.ReturnType.GenericTypeArguments[0];
        }

        /// <summary>
        /// Verifica se as propriedades públicas da entidade estão com set protegido (não público).
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static bool CheckIfEntityPropertiesHavePublicOrInternalSetAccessor<TEntity>()
        {
            PropertyInfo[] props = typeof(TEntity).GetProperties();
            MethodInfo setInfo;

            foreach (PropertyInfo prop in props)
            {
                setInfo = prop.GetSetMethod(true);

                if (prop.CanWrite && (setInfo.IsPublic || setInfo.IsAssembly))
                    return false;
            }

            return true;
        }
    }
}