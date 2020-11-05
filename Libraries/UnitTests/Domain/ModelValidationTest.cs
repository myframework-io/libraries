using Myframework.Libraries.Common.Extensions;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Common.Validators;
using System;
using System.Linq;
using Xunit;

namespace Domain
{
    public class ModelValidationTest
    {
        [Fact]
        public void ModelValidatiorsOkTest()
        {
            Result<ModelTest> result = ModelTest.Criar("My Framework", new DateTime(1987, 8, 16), "157.151.171-99");
            Assert.True(result.Valid);
            Assert.NotNull(result.Value);
            Assert.Empty(result.Validations);
        }

        [Fact]
        public void ModelValidatiorsNomeNOkTest()
        {
            Result<ModelTest> result = ModelTest.Criar("Al", new DateTime(1987, 8, 16), "157.151.171-99");
            Assert.False(result.Valid);
            Assert.Null(result.Value);
            Assert.NotEmpty(result.Validations);
            Assert.Equal("Campo deve ter ao menos 3 caracteres.", result.Validations.First().Message);
            Assert.Equal("ModelTest.Nome", result.Validations.First().Attribute);
        }

        [Fact]
        public void ModelValidatiorsMustMaiorDeIdadeComCpfObrigatorioTest()
        {
            Result<ModelTest> result = ModelTest.Criar("Myfr", new DateTime(1987, 8, 16), null);
            Assert.False(result.Valid);
            Assert.Null(result.Value);
            Assert.NotEmpty(result.Validations);
            Assert.Equal("O CPF é obrigatório.", result.Validations.First().Message);
            Assert.Equal("ModelTest.Cpf", result.Validations.First().Attribute);
        }

        [Fact]
        public void ModelValidatiorsMustMenorDeIdadeComCpfNAOObrigatorioTest()
        {
            Result<ModelTest> result = ModelTest.Criar("Myfr", new DateTime(2009, 8, 16), null);
            Assert.True(result.Valid);
            Assert.NotNull(result.Value);
            Assert.Empty(result.Validations);
        }

        private class ModelTest
        {
            private ModelTest() { }

            public int Id { get; private set; }
            public string Nome { get; private set; }
            public DateTime DataNascimento { get; private set; }
            public string Cpf { get; private set; }

            public static Result<ModelTest> Criar(string nome, DateTime nascimento, string cpf)
            {
                var result = new Result<ModelTest>();

                var model = new ModelTest();

                model.ValidarCriacao(result, nome, nascimento, cpf);

                if (!result.Valid)
                    return result;

                model.Id = 0;
                model.Nome = nome;
                model.DataNascimento = nascimento;
                model.Cpf = cpf;

                result.Value = model;

                return result;
            }

            private void ValidarCriacao(Result result, string nome, DateTime nascimento, string cpf)
            {
                string nameofClass = nameof(ModelTest);

                result.AddValidationsIfFails($"{nameofClass}.{nameof(Nome)}", ValidarNome(nome));
                result.AddValidationsIfFails($"{nameofClass}.{nameof(DataNascimento)}", ValidarDataNascimento(nascimento));
                result.AddValidationsIfFails($"{nameofClass}.{nameof(Cpf)}", ValidarMultiplasRegrasDependentes(nascimento, cpf));
            }

            private IValidatorResult ValidarNome(string nome) => nome
                .NotEmpty("Campo obrigatório.")
                .MinLength(3, "Campo deve ter ao menos 3 caracteres.");

            private IValidatorResult ValidarDataNascimento(DateTime nascimento) => nascimento
                .LessThanOrEqual(DateTime.Today, "A data de nascimento deve ser inferior a data atual.");

            private IValidatorResult ValidarMultiplasRegrasDependentes(DateTime nascimento, string cpf) => cpf
                .Must(() =>
                {
                    int idade = nascimento.CalculateAge();
                    if (idade >= 18 && cpf.IsNullOrWhiteSpace())
                        return false;

                    return true;
                }, "O CPF é obrigatório.");
        }
    }
}