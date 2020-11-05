using Myframework.Libraries.Common.Pagination;
using Xunit;

namespace Common.Pagination
{
    public class PaggingCalculationTest
    {
        [Theory(DisplayName = "Pagination")]
        [InlineData(0, 15, 5, 3)]
        [InlineData(1, 16, 5, 4)]
        [InlineData(1, 14, 5, 3)]
        public void Pagination(int page, int totalItems, int itensPerPage, int totalPages)
        {
            var pagination = new PaggingCalculation(page, totalItems, itensPerPage);

            Assert.Equal(page, pagination.Page);
            Assert.Equal(itensPerPage, pagination.ItensPerPage);
            Assert.Equal(totalItems, pagination.TotalItens);
            Assert.Equal(totalPages, pagination.TotalPages);
        }
    }
}