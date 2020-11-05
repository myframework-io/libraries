using Myframework.Libraries.Common.Extensions;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Xunit;

namespace Common.Extension
{
    public class ObjectExtensionTest
    {
        [Fact]
        public void IsNullTest()
        {
            ObjectClass teste = null;
            Assert.True(teste.IsNull());

            teste = new ObjectClass();
            Assert.False(teste.IsNull());
        }

        [Fact]
        public void IsNotNullTest()
        {
            ObjectClass teste = null;
            Assert.False(teste.IsNotNull());

            teste = new ObjectClass();
            Assert.True(teste.IsNotNull());
        }

        [Fact]
        public void ToQueryStringOkTest()
        {
            var obj = new ObjectClass
            {
                Idade = 12,
                Nome = "Um cara Qual Você",
                Valor = 564.88m,
                ValorDouble = 67.857D,
                ValorFloat = 18.671F,
                Seconds = new List<SecondObjectClass>
                {
                    new SecondObjectClass
                    {
                        Prop1 = "teste",
                        Prop2 = "sadklsadl"
                    },
                    new SecondObjectClass
                    {
                        Prop1 = "sec2",
                        Prop2 = "secdsad2"
                    },
                }
            };

            string queryStringAlvo = "Idade=12&Nome=Um+cara+Qual+Voc%C3%AA&Valor=564.88&ValorFloat=18.671&ValorDouble=67.857&Seconds%5B0%5D.Prop1=teste&Seconds%5B0%5D.Prop2=sadklsadl&Seconds%5B1%5D.Prop1=sec2&Seconds%5B1%5D.Prop2=secdsad2";

            string queryStringSincrona = obj.ToQueryString();
            string queryStringAssincrona = obj.ToQueryStringAsync().GetAwaiter().GetResult();

            Assert.Equal(queryStringSincrona, queryStringAlvo);
            Assert.Equal(queryStringAssincrona, queryStringAlvo);
        }

        [Fact]
        public void ToQueryStringObjetoNuloTest()
        {
            ObjectClass obj = null;
            string queryString = obj.ToQueryString();

            Assert.Null(queryString);

            var objVoid = new VoidObjectClass();
            string queryStringVoid = objVoid.ToQueryString();

            Assert.Null(queryStringVoid);
        }

        [Fact]
        public void ToQueryStringMixedMemberAttributeTest()
        {
            var obj = new MixedObjectClass
            {
                Idade = 12,
                Nome = "Um cara Qual Você",
                Valor = 564.88m,
                ValorDouble = 67.857D,
                ValorFloat = 18.671F,
                Seconds = new List<SecondObjectClass>
                {
                    new SecondObjectClass
                    {
                        Prop1 = "teste",
                        Prop2 = "sadklsadl"
                    },
                    new SecondObjectClass
                    {
                        Prop1 = "sec2",
                        Prop2 = "secdsad2"
                    },
                }
            };

            string queryStringAlvo = "Idade=12&Nome=Um+cara+Qual+Voc%C3%AA&Valor=564.88&ValorFloat=18.671&ValorDouble=67.857&Seconds%5B0%5D.Prop1=teste&Seconds%5B0%5D.Prop2=sadklsadl&Seconds%5B1%5D.Prop1=sec2&Seconds%5B1%5D.Prop2=secdsad2";

            string queryStringSincrona = obj.ToQueryString();
            string queryStringAssincrona = obj.ToQueryStringAsync().GetAwaiter().GetResult();

            Assert.Equal(queryStringSincrona, queryStringAlvo);
            Assert.Equal(queryStringAssincrona, queryStringAlvo);
        }

        public class VoidObjectClass
        {

        }

        public class ObjectClass
        {
            [JsonPropertyName("idade")]
            public int Idade { get; set; }

            [JsonPropertyName("nome")]
            public string Nome { get; set; }

            [JsonPropertyName("valor")]
            public decimal Valor { get; set; }

            [JsonPropertyName("valorFloat")]
            public float ValorFloat { get; set; }

            [JsonPropertyName("valorDouble")]
            public double ValorDouble { get; set; }

            [JsonPropertyName("second")]
            public List<SecondObjectClass> Seconds { get; set; }
        }

        public class SecondObjectClass
        {
            [JsonPropertyName("prop1")]
            public string Prop1 { get; set; }

            [JsonPropertyName("prop2")]
            public string Prop2 { get; set; }
        }

        public class MixedObjectClass
        {
            public int Idade { get; set; }

            [JsonPropertyName("nome")]
            public string Nome { get; set; }

            [JsonPropertyName("valor")]
            public decimal Valor { get; set; }

            public float ValorFloat { get; set; }

            [JsonPropertyName("valorDouble")]
            public double ValorDouble { get; set; }

            [JsonPropertyName("second")]
            public List<SecondObjectClass> Seconds { get; set; }
        }
    }
}