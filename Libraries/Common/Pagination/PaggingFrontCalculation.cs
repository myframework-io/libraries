using System.Collections.Generic;

namespace Myframework.Libraries.Common.Pagination
{
    /// <summary>
    /// Classe que realiza cálculo de paginação para criação de componentes de paginação.
    /// </summary>
    public class PaggingFrontCalculation : PaggingCalculation
    {
        /// <summary>
        /// Construtor padrão.
        /// Realiza cálculos da paginação.
        /// </summary>
        /// <param name="page">Página atual/selecionada.</param>
        /// <param name="totalItems">Quantidade total de itens.</param>
        /// <param name="itemsPerPage">Quantidade de itens por página.</param>
        /// <param name="linkVisibleCount">Quantidade de links visíveis na paginação.</param>
        public PaggingFrontCalculation(int page, int totalItems, int itemsPerPage, int linkVisibleCount = 5)
            : base(page, totalItems, itemsPerPage)
        {
            LinkVisibleCount = linkVisibleCount;

            // Inicialmente a quantidade de links à esquerda da pagina atual (que fica no meio dos links), é calculada pela quantidade de links menos a pagina atual, dividido por dois
            int qtdPaginasAEsquerda = (linkVisibleCount - 1) / 2;
            int qtdPaginasADireita = linkVisibleCount - qtdPaginasAEsquerda - 1;

            // Verificar quantos itens cabem na esqueda
            if (page - qtdPaginasAEsquerda < 0)
            {
                qtdPaginasAEsquerda = page;
                qtdPaginasADireita = linkVisibleCount - qtdPaginasAEsquerda - 1;
            }

            // Verificar quantos itens cabem na direita
            if (page + qtdPaginasADireita >= TotalPages)
            {
                qtdPaginasADireita = TotalPages - page - 1;
                qtdPaginasAEsquerda = linkVisibleCount - qtdPaginasADireita - 1;
            }

            PagesToShow = new List<int>();
            for (int i = page - qtdPaginasAEsquerda; i <= page + qtdPaginasADireita; i++)
            {
                if (i < 0)
                    continue;

                PagesToShow.Add(i);
            }

            IndexLastPage = TotalPages - 1;

            if (page == 0)
                IndexPreviousPage = 0;
            else
                IndexPreviousPage = page - 1;

            if (page == IndexLastPage)
                IndexNextPage = IndexLastPage;
            else
                IndexNextPage = page + 1;

            ShowPreviousLink = page > 0;
            ShowNextLink = page != IndexLastPage;

            ShowFirstLink = ShowPreviousLink;
            ShowLastLink = ShowNextLink;

            IndexFirstItemPage = 0;
            IndexLastItemPage = TotalPages - 1;
        }

        /// <summary>Quantidade de links visíveis na paginação.</summary>
        public int LinkVisibleCount { get; private set; }

        /// <summary>Index (baseado em 1) do primeiro item da página.</summary>
        public int IndexFirstItemPage { get; private set; }

        /// <summary>Index (baseado em 1) do último item da página.</summary>
        public int IndexLastItemPage { get; private set; }

        /// <summary>Página anterior à página atual. Se não houver página anterior, recebe o valor da página atual.</summary>
        public int IndexPreviousPage { get; private set; }

        /// <summary>Página posterior à página atual. Se não houver página posterior, recebe o valor da página atual.</summary>
        public int IndexNextPage { get; private set; }

        /// <summary>Última página da paginação.</summary>
        public int IndexLastPage { get; private set; }

        /// <summary>Lista com as páginas que devem ser exibidas (como link ou outro componente).</summary>
        public List<int> PagesToShow { get; private set; }

        /// <summary>Indica se deve mostrar o link anterior para a página atual. Ex: se a página atual for 0, significa que não precisamos mostrar o link.</summary>
        public bool ShowPreviousLink { get; private set; }

        /// <summary>Indica se deve mostrar o link posterior para a página atual. Ex: se a página atual for igual ao a última página, significa que não precisamos mostrar o link.</summary>
        public bool ShowNextLink { get; private set; }

        /// <summary>Indica se deve mostrar o link para o primeiro item. Segue a mesma regra do LinkAnterior, combinada com o parâmetro especificado no construtor.</summary>
        public bool ShowFirstLink { get; private set; }

        /// <summary>Indica se deve mostrar o link para o ultimo item. Segue a mesma regra do LinkPosterior, combinada com o parâmetro especificado no construtor.</summary>
        public bool ShowLastLink { get; private set; }
    }
}