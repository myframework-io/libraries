using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para testes.
    /// </summary>
    public static class TestHelper
    {
        private static readonly List<Type> mockableValuesTypes =
            new List<Type>
            {
                typeof(bool), typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(IntPtr), typeof(UIntPtr), typeof(double), typeof(float), typeof(decimal), typeof(bool?), typeof(byte?), typeof(sbyte?), typeof(short?), typeof(ushort?), typeof(int?), typeof(uint?), typeof(long?), typeof(ulong?), typeof(IntPtr?), typeof(UIntPtr?), typeof(double?), typeof(float?), typeof(decimal?), typeof(char), typeof(char?), typeof(DateTime), typeof(DateTime?), typeof(Enum), typeof(string)
            };

        /// <summary>
        /// Mocka um objeto com valores aleatórios.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="ignoreTypes"></param>
        /// <returns></returns>
        public static void MockObject<T>(T t, params Type[] ignoreTypes)
        {
            var rd = new Random();
            PropertyInfo[] properties = t.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (!(prop.CanWrite && prop.GetSetMethod(true).IsPublic))
                    continue;

                Type propType = prop.PropertyType;

                if (ignoreTypes.Contains(propType))
                    continue;

                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                    continue;

                if (propType.IsArray || IsPropertyACollection(prop))
                {
                    var tProp = (IList)GetNewInstance(propType);
                    Type itemType = tProp.GetType().GetGenericArguments().First();

                    for (int i = 0; i < 2; i++)
                    {
                        if (IsMockableValueType(itemType))
                            tProp.Add(MockPrimitiveValue(itemType));
                        else
                        {
                            object obj = GetNewInstance(itemType);
                            MockObject(obj);
                            tProp.Add(obj);
                        }
                    }

                    prop.SetValue(t, tProp);

                    continue;
                }

                if (IsMockableValueType(propType))
                {
                    prop.SetValue(t, MockPrimitiveValue(propType));
                    continue;
                }

                if (propType.IsClass)
                {
                    object tProp = GetNewInstance(propType);
                    MockObject(tProp);
                    prop.SetValue(t, tProp);
                    continue;
                }

                throw new NotImplementedException("Mock para tipo não implementado.");
            }
        }

        /// <summary>
        /// Cria os asserts para testes de mapeamento/conversão entre classes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="nome"></param>
        /// <param name="nomeComp"></param>
        /// <returns></returns>
        public static string CreateMapsAsserts<T>(T t, string nome, string nomeComp)
        {
            var sb = new StringBuilder(); ;

            var rd = new Random();
            PropertyInfo[] properties = t.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (!(prop.CanWrite && prop.GetSetMethod(true).IsPublic))
                    continue;

                Type propType = prop.PropertyType;

                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                    continue;

                if (propType.IsArray || IsPropertyACollection(prop))
                {
                    var tProp = (IList)GetNewInstance(propType);
                    Type itemType = tProp.GetType().GetGenericArguments().First();

                    if (!IsMockableValueType(itemType))
                    {
                        sb.AppendLine("");
                        sb.AppendLine(CreateMapsAsserts(GetNewInstance(itemType), $"{nome}.{prop.Name}", $"{nomeComp}.{prop.Name}"));
                    }

                    continue;
                }

                if (IsMockableValueType(propType))
                {
                    sb.AppendLine($"Assert.AreEqual({nome}.{prop.Name}, {nomeComp}.{prop.Name});");
                    continue;
                }

                if (propType.IsClass)
                {
                    object tProp = GetNewInstance(propType);
                    sb.AppendLine("");
                    sb.AppendLine(CreateMapsAsserts(tProp, $"{nome}.{prop.Name}", $"{nomeComp}.{prop.Name}"));
                    continue;
                }
            }

            return sb.ToString();
        }

        private static bool IsMockableValueType(Type type)
        {
            if (IsNullableEnum(type))
                return true;

            return mockableValuesTypes.Contains(type) || mockableValuesTypes.Contains(type.BaseType);
        }

        private static bool IsNullableEnum(Type type)
        {
            Type u = Nullable.GetUnderlyingType(type);
            return u != null && u.IsEnum;
        }

        private static object MockPrimitiveValue(Type type)
        {
            if (!IsMockableValueType(type))
                return null;

            var rd = new Random();

            if (type == typeof(string))
                return $"{type.Name} {rd.Next(0, 5000)}";

            if (type == typeof(int) || type == typeof(int?))
                return rd.Next(0, int.MaxValue);

            if (type == typeof(long) || type == typeof(long?))
                return Convert.ToInt64(rd.Next(0, int.MaxValue));

            if (type == typeof(float) || type == typeof(float?))
                return Convert.ToSingle(rd.NextDouble());

            if (type == typeof(double) || type == typeof(double?))
                return Convert.ToDouble(rd.NextDouble());

            if (type == typeof(decimal) || type == typeof(decimal?))
                return Convert.ToDecimal(rd.NextDouble());

            if (type == typeof(byte) || type == typeof(byte?))
                return Convert.ToByte(rd.Next(0, byte.MaxValue));

            if (type == typeof(short) || type == typeof(short?))
                return Convert.ToInt16(rd.Next(0, short.MaxValue));

            if (type == typeof(bool) || type == typeof(bool?))
                return true;

            bool enumNullable = IsNullableEnum(type);
            if (type.BaseType == typeof(Enum) || enumNullable)
            {
                Array values;

                if (enumNullable)
                    values = Enum.GetValues(Nullable.GetUnderlyingType(type));
                else
                    values = Enum.GetValues(type);

                int index = rd.Next(0, values.Length - 1);

                return values.GetValue(index);
            }

            if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                int ano = rd.Next(1950, 2018);
                int mes = rd.Next(1, 12);

                return new DateTime(ano, mes, rd.Next(1, DateTime.DaysInMonth(ano, mes)));
            }

            return null;
        }

        private static bool IsPropertyACollection(PropertyInfo property) => (!typeof(string).Equals(property.PropertyType) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType));

        private static object GetNewInstance(Type tipo, int lengthArray = 0)
        {
            if (tipo.IsArray)
                return Activator.CreateInstance(tipo, new object[] { lengthArray });
            else
            {
                ConstructorInfo c = tipo.GetTypeInfo().DeclaredConstructors.First(ci => ci.GetParameters().Length == 0);
                return c.Invoke(Type.EmptyTypes);
            }
        }
    }
}