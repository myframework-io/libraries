using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.Queries
{
    /// <summary>
    /// View model base para queries paginadas.
    /// </summary>
    [DataContract]
    public class BasePageViewModel
    {
        /// <summary>
        /// Número da página, baseada em zero.
        /// </summary>
        [DataMember] public int Page { get; set; }

        /// <summary>
        /// Quantidade de registros por página.
        /// </summary>
        [DataMember] public int ItensPerPage { get; set; }
    }
}