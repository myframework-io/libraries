using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Infra.Http.Client.HttpResponseToResultDeserializers;
using ServicesClient.Messages;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using Xunit;

namespace Infra.Http.ResponseDeserializers
{
    public class HttpResponseToResultJsonDeserializerTest
    {
        [Fact]
        public void DeserializeResultOKTest()
        {
            string resultOk = @"
                {
                    ""response"": {
                        ""localidade"": 0,
                        ""idCorretor"": 171611,
                        ""idProduto"": -1,
                        ""idTipoProduto"": 4740,
                        ""profissao"": ""prof""
                    },
                    ""message"": ""Success"",
                    ""validations"": [],
                    ""protocol"": ""9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56""
                }";

            var protocolo = new Guid("9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56");

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultOk);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<RetornoResponseMessage> result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal(0, result.Value.Localidade);
            Assert.Equal(171611, result.Value.IdCorretor);
            Assert.Equal(-1, result.Value.IdProduto);
            Assert.Equal(4740, result.Value.IdTipoProduto);
            Assert.Equal("prof", result.Value.Profissao);
            Assert.Equal("Success", result.Message);
            Assert.Equal(new Guid("9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56"), result.Protocol);
        }

        [Fact]
        public void DeserializeResultOKTest2()
        {
            string resultOk = @"
                {""response"":{""unitAdmissionId"":""91319879-91c3-4306-9a5d-3b8107e42cd9"",""unitId"":""5e04bad7-6c18-4b36-9628-3bd522e162c3"",""tenantId"":""755136e2-dab2-474e-af6c-af29da4674b2"",""unitAdmissionDate"":""2018-10-15T15:21:00.000"",""hospitalAdmissionDate"":""2018-10-15T15:21:00.000""},""validations"":[],""message"":""Success"",""protocol"":""b0a99a67-3a3e-4dae-825e-41de64967f2e""}";

            var protocolo = new Guid("b0a99a67-3a3e-4dae-825e-41de64967f2e");

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultOk);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<GetUnitAdmissionForDiagnosisResponseMessage> result = deserializer.DeserializeAsync<GetUnitAdmissionForDiagnosisResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.True(result.Valid);
            Assert.Equal(protocolo, result.Protocol);
        }

        [Fact]
        public void DeserializeResultVazioOuNuloTest()
        {
            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, "");
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<RetornoResponseMessage> result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Null(result.Value);

            deserializer = new HttpResponseToResultJsonDeserializer();
            response.Content = null;
            result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Null(result.Value);
        }

        [Fact]
        public void DeserializeResultCampoFaltandoTest()
        {
            string resultCampoFaltando = @"
                {
                    ""response"": {
                        ""localidade"": 0,
                        ""idCorretor"": 171611
                    },
                    ""message"": ""Success"",
                    ""validations"": [],
                    ""protocol"": ""9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56""
                }";

            string resultCampoFaltando2 = @"
                {
                    ""response"": {
                        ""localidade"": 0,
                        ""idCorretor"": 171611
                    },
                    ""message"": ""Success"",
                    ""validations"": []
                }";

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultCampoFaltando);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<RetornoResponseMessage> result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal(0, result.Value.Localidade);
            Assert.Equal(171611, result.Value.IdCorretor);
            Assert.Equal(new Guid("9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56"), result.Protocol);

            byte[] byteArray2 = Encoding.UTF8.GetBytes(resultCampoFaltando2);
            var stream2 = new MemoryStream(byteArray2);
            response = MockHttpResponse(HttpStatusCode.OK, resultCampoFaltando2);
            result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal(0, result.Value.Localidade);
            Assert.Equal(171611, result.Value.IdCorretor);
            Assert.Equal("Success", result.Message);
            Assert.NotEqual(Guid.Empty, result.Protocol);
        }

        [Fact]
        public void DeserializeResultChamadaExternaTest()
        {
            string resultExterno = @"
                {
                    ""_id"":""12414773707"",
                    ""_metadata"":{
                    ""pessoas"":{
                        ""lastUpdate"":""2017 -12-31T12:12:46.663Z"",
                        ""updatedAt"":""2018 -01-01T22:42:45.458Z""
                    }},
                    ""pis"":""13146233583""}
                ";

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultExterno);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<RetornoResponseMessage2> result = deserializer.DeserializeAsync<RetornoResponseMessage2>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal("13146233583", result.Value.Pis);
        }

        [Fact]
        public void DeserializeResultCampoFaltandoSemEstruturaResultTest()
        {
            string resultCampoFaltando = @"
                {
                    ""localidade"": 0,
                    ""idCorretor"": 171611
                }";

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultCampoFaltando);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<RetornoResponseMessage> result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal(0, result.Value.Localidade);
            Assert.Equal(171611, result.Value.IdCorretor);
        }

        [Fact]
        public void DeserializeResultRetornoInvalidoTest()
        {
            string resultRetornoInvalido = @"
                {
                    ""response"": {
                        ""aaaaa"": 1
                    },
                    ""message"": ""Success"",
                    ""validations"": [],
                    ""protocol"": ""9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56""
                }";

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultRetornoInvalido);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<RetornoResponseMessage> result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal(default(int), result.Value.IdCorretor);
            Assert.Equal(default(int), result.Value.IdProduto);
            Assert.Equal(default(int), result.Value.IdTipoProduto);
            Assert.Equal(default(int), result.Value.Localidade);
            Assert.Equal(default(string), result.Value.Profissao);
            Assert.Equal("Success", result.Message);
            Assert.Equal(new Guid("9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56"), result.Protocol);
        }

        //[Fact]
        //public void DeserializeResultBadRequestTest()
        //{
        //    string resultErroValidacao = @"
        //    {
        //        ""response"": null,
        //        ""message"": ""Validação - Campos."",
        //        ""validations"": [{""Atributo"": ""Abc"", ""message"": ""Uma mensagem qlq""}],
        //        ""protocol"": ""9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56""
        //    }";

        //    HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultErroValidacao);
        //    HttpResponseToResultJsonDeserializer deserializer = new HttpResponseToResultJsonDeserializer();
        //    Result<RetornoResponseMessage> result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

        //    Assert.NotNull(result);
        //    Assert.Null(result.Value);
        //    Assert.Equal("Validação - Campos.", result.Message);
        //    Assert.Single(result.Validations);
        //    Assert.Equal("Abc", result.Validations[0].Atributo);
        //    Assert.Equal("Uma mensagem qlq", result.Validations[0].Mensagem);
        //    Assert.Equal(new Guid("9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56"), result.Protocol);
        //}

        [Fact]
        public void DeserializeResultExternoTest()
        {
            string resultExterno = @"
            {
                ""localidade"": 0,
                ""idCorretor"": 171611,
                ""idProduto"": -1,
                ""idTipoProduto"": 4740,
                ""profissao"": ""prof""
            }";

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultExterno);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<RetornoResponseMessage> result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal(0, result.Value.Localidade);
            Assert.Equal(171611, result.Value.IdCorretor);
            Assert.Equal(-1, result.Value.IdProduto);
            Assert.Equal(4740, result.Value.IdTipoProduto);
            Assert.Equal("prof", result.Value.Profissao);
            Assert.Equal("Success", result.Message);
            Assert.NotEqual(Guid.Empty, result.Protocol);
        }

        [Fact]
        public void DeserializeResultJsonMalFormatadoTest()
        {
            string resultExternoMalFormatado = @"
            {
                ""localidade
            }";

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultExternoMalFormatado);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<RetornoResponseMessage> result = deserializer.DeserializeAsync<RetornoResponseMessage>(response).GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Null(result.Value);
            Assert.Single(result.Validations);
            Assert.Equal("Json", result.Validations[0].Attribute);
            Assert.Equal(resultExternoMalFormatado.ToString(), result.Validations[0].Message);
            Assert.NotEqual("Success", result.Message);
            Assert.NotEqual(result.Protocol, Guid.Empty);
        }

        [Theory]
        [InlineData("pt-BR", "1/22/2019 12:00:05 AM", 2019, 1, 22, 0, 0, 5)]
        [InlineData("en-US", "1/22/2019 12:00:05 AM", 2019, 1, 22, 0, 0, 5)]
        //[InlineData("pt-BR", "22/1/2019 00:00:05", 2019, 1, 22, 0, 0, 5)]
        [InlineData("en-US", "12/1/2019 00:00:05", 2019, 12, 01, 0, 0, 5)]
        public void DeserializeDates(string culture, string date1, int expectedYear, int expectedMonth, int expectedDay, int expectedHour, int expectedMinute, int expectedSecond)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);

            string resultOk = @"
                {
                    'response': {
                        'unitAdmissionId': '9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56',
                        'unitId': '9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56',
                        'tenantId': '9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56',
                        'unitAdmissionDate': '" + date1 + @"',
                        'hospitalAdmissionDate': '" + date1 + @"'
                    },
                    'message': 'Success',
                    'validations': [],
                    'protocol': '9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56'
                }";

            var protocolo = new Guid("9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56");

            HttpResponseMessage response = MockHttpResponse(HttpStatusCode.OK, resultOk);
            var deserializer = new HttpResponseToResultJsonDeserializer();
            Result<GetUnitAdmissionForDiagnosisResponseMessage> result =
                deserializer.DeserializeAsync<GetUnitAdmissionForDiagnosisResponseMessage>(response).GetAwaiter().GetResult();

            DateTime dateToEval = result.Value.UnitAdmissionDate;

            Assert.NotNull(result);
            Assert.Equal(expectedYear, dateToEval.Year);
            Assert.Equal(expectedMonth, dateToEval.Month);
            Assert.Equal(expectedDay, dateToEval.Day);
            Assert.Equal(expectedHour, dateToEval.Hour);
            Assert.Equal(expectedMinute, dateToEval.Minute);
            Assert.Equal(expectedSecond, dateToEval.Second);
            Assert.Equal("Success", result.Message);
            Assert.Equal(new Guid("9bcf75c6-ba0f-40f1-ab01-62fb5fa82e56"), result.Protocol);
        }

        private HttpResponseMessage MockHttpResponse(HttpStatusCode httpStatus, string json)
        {
            var response = new HttpResponseMessage(httpStatus)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return response;
        }

        [DataContract]
        public class GetUnitAdmissionForDiagnosisOnDateRequestMessage
        {
            [DataMember] public Guid HospitalAdmissionId { get; set; }
            [DataMember] public DateTime Date { get; set; }
        }

        [DataContract]
        public class GetUnitAdmissionForDiagnosisResponseMessage
        {
            [DataMember] public Guid UnitAdmissionId { get; set; }
            [DataMember] public Guid UnitId { get; set; }
            [DataMember] public Guid TenantId { get; set; }
            [DataMember] public DateTime UnitAdmissionDate { get; set; }
            [DataMember] public DateTime? HospitalAdmissionDate { get; set; }
        }
    }
}