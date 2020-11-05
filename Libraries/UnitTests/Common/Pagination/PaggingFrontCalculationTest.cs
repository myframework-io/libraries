using Myframework.Libraries.Common.Pagination;
using Xunit;

namespace Common.Pagination
{
    public class PaggingFrontCalculationTest
    {
        [Theory(DisplayName = "Pagging for front-end")]
        [InlineData(7, 240, 15, 5, 16, 0, 6, 8, 15)]
        public void PaggingFrontTest(int page, int totalItems, int itemsPerPage, int linkVisibleCount, int totalPages, int indexFirstItemPage, int indexPreviousPage, int indexNextPage, int indexLastPage)
        {
            var pagging = new PaggingFrontCalculation(page, totalItems, itemsPerPage, linkVisibleCount);

            Assert.Equal(totalPages, pagging.TotalPages);
            Assert.Equal(indexFirstItemPage, pagging.IndexFirstItemPage);
            Assert.Equal(indexPreviousPage, pagging.IndexPreviousPage);
            Assert.Equal(indexNextPage, pagging.IndexNextPage);
            Assert.Equal(indexLastPage, pagging.IndexLastPage);
        }
    }
}