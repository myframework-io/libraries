using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Myframework.Libraries.Domain.SeedWork
{
    /// <summary>
    /// Classe que representa um enum, mas com recursos de OO (object-oriented).
    /// </summary>
    public abstract class Enumeration<TEnumeration>
        where TEnumeration : struct
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        protected Enumeration() { }

        /// <summary>
        /// Construtor para iniciar o enumerador.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        protected Enumeration(TEnumeration id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Inteiro para representar o enumerador.
        /// </summary>
        public TEnumeration Id { get; private set; }

        /// <summary>
        /// Descrição do enumerador.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Retorna a descrição do enumarador.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;

        /// <summary>
        /// Retorna todos os possíveis valores para o enumerador.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<TEnum> GetAll<TEnum>()
            where TEnum : Enumeration<TEnumeration>
        {
            FieldInfo[] fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<TEnum>().ToList();
        }

        /// <summary>
        /// Verifica se o objeto informado é igual a esta instância.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration<TEnumeration>;

            if (otherValue == null)
                return false;

            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        /// <summary>
        /// Retorna o hash da instância.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// Retorna o eumerador que corresponde ao ID informado.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TEnum FromId<TEnum>(TEnumeration id)
             where TEnum : Enumeration<TEnumeration> => Parse<TEnum>(item => item.Id.Equals(id));

        /// <summary>
        /// Retorna o enumerador a partir do nome.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static TEnum FromName<TEnum>(string displayName)
            where TEnum : Enumeration<TEnumeration> => Parse<TEnum>(item => item.Name == displayName);

        private static TEnum Parse<TEnum>(Func<TEnum, bool> predicate)
            where TEnum : Enumeration<TEnumeration> => GetAll<TEnum>().FirstOrDefault(predicate);
    }
}