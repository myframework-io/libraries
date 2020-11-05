using Myframework.Libraries.Common.Pagination;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Common.Pagination
{
    public class PagedListTest
    {
        [Theory(DisplayName = "PagedList")]
        [InlineData(0, 15, 5, 3)]
        [InlineData(1, 16, 5, 4)]
        [InlineData(1, 14, 5, 3)]
        public void PagedList(int page, int totalItens, int itensPerPage, int totalPages)
        {
            var itens = new List<PaginationTestClass>();

            for (int i = 0; i < totalItens; i++)
            {
                itens.Add(new PaginationTestClass { Id = i });
            }

            var pagedList = new PagedList<PaginationTestClass>(itens.Skip(page * itensPerPage).Take(itensPerPage).ToList(), page, totalItens, itensPerPage);

            Assert.Equal(page, pagedList.Page);
            Assert.Equal(itensPerPage, pagedList.ItensPerPage);
            Assert.Equal(totalItens, pagedList.TotalItens);
            Assert.Equal(totalPages, pagedList.TotalPages);
            Assert.Equal(itensPerPage, pagedList.Itens.Count);
        }

        public class PaginationTestClass
        {
            public int Id { get; set; }
        }
    }
}