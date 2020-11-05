using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Common.Pagination
{
    /// <summary>
    /// Classe para representar uma paginação.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class PagedList<T>
    {
        public PagedList() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itens"></param>
        /// <param name="page"></param>
        /// <param name="totalItens"></param>
        /// <param name="itensPerPage"></param>
        public PagedList(List<T> itens, int page, int totalItens, int itensPerPage)
        {
            Itens = itens;
            Page = page;
            TotalItens = totalItens;
            ItensPerPage = itensPerPage;

            var pagging = new PaggingCalculation(page, totalItens, itensPerPage);
            TotalPages = pagging.TotalPages;
        }

        /// <summary>
        /// Itens paginados.
        /// </summary>
        [DataMember]
        public List<T> Itens { get; set; }

        /// <summary>
        /// Página atual.
        /// </summary>
        [DataMember]
        public int Page { get; set; }

        /// <summary>
        /// Itens por página.
        /// </summary>
        [DataMember]
        public int ItensPerPage { get; set; }

        /// <summary>
        /// Total de itens para a consulta.
        /// </summary>
        [DataMember]
        public int TotalItens { get; private set; }

        /// <summary>
        /// Total de páginas.
        /// </summary>
        [DataMember]
        public int TotalPages { get; set; }
    }
}