using System.ComponentModel;

namespace Myframework.Libraries.Common.Enums
{
    /// <summary>
    /// Enumerador para definição de pontuação para senhas.
    /// </summary>
    public enum PasswordScore
    {
        /// <summary>Senha em branco equivale a nenhum ponto.</summary>
        [Description("Blank")]
        Blank = 0,

        /// <summary>Senha muito fraca equivale a um ponto.</summary>
        [Description("Very Weak")]
        VeryWeak = 1,

        /// <summary>Senha fraca equivale a dois pontos.</summary>
        [Description("Weak")]
        Weak = 2,

        /// <summary>Senha média equivale a três pontos.</summary>
        [Description("Good")]
        Good = 3,

        /// <summary>Senha forte equivale a quatro pontos.</summary>
        [Description("Strong")]
        Strong = 4,

        /// <summary>Senha muito forte equivale a cinco pontos.</summary>
        [Description("Very Strong")]
        VeryStrong = 5
    }
}