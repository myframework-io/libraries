using Myframework.Libraries.Common.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Common.Extension
{
    public class IEnumerableExtensionsTests
    {
        [Theory(DisplayName = "To paged list")]
        [InlineData(0, 2, true, 3)]
        [InlineData(1, 2, true, 3)]
        [InlineData(2, 2, true, 3)]
        public void ToPagedListTest(int page, int itensPerPage, bool orderAscending, int totalPage)
        {
            var list = new List<int> { 13, 999999999, 166, 654646, 6484 };

            var listaPaginada = list.ToPagedList(order: it => it, page: page, itensPerPage: itensPerPage, orderAscending: orderAscending);

            Assert.Equal(page, listaPaginada.Page);
            Assert.Equal(itensPerPage, listaPaginada.ItensPerPage);
            Assert.Equal(totalPage, listaPaginada.TotalPages);
            Assert.Equal(list.Skip(page * itensPerPage).Take(itensPerPage).Count(), listaPaginada.Itens.Count);

            list = list.OrderBy(it => it).ToList();

            for (int i = (page * itensPerPage); i < (itensPerPage < list.Count ? itensPerPage : list.Count); i++)
            {
                Assert.Contains(list[i], listaPaginada.Itens);
            }

            Assert.Equal(list.Count, listaPaginada.TotalItens);
        }

        [Theory(DisplayName = "To string")]
        [InlineData(",,", ",", "", "", "")]
        [InlineData(",", ",", "", null, "")]
        [InlineData("", ",", "", null, null)]
        [InlineData(null, ",", null, null, null)]
        [InlineData("abc,,def", ",", "abc", "", "def")]
        [InlineData("1,2,3", ",", "1", "2", "3")]
        [InlineData("1-2-3", "-", "1", "2", "3")]
        [InlineData(" 1, 2 ,3 ", ",", " 1", " 2 ", "3 ")]
        public void ToStringTest(string expectedStr, string delimiter, params string[] arrayCollection) => Assert.Equal(expectedStr, arrayCollection.ToList().ToString(delimiter));

        [Theory(DisplayName = "To string wrapp (equal start and finish wrapp value)")]
        [InlineData("'','',''", "'", ",", "", "", "")]
        [InlineData("'',''", "'", ",", "", null, "")]
        [InlineData("''", "'", ",", "", null, null)]
        [InlineData(null, "'", ",", null, null, null)]
        [InlineData("'abc','','def'", "'", ",", "abc", "", "def")]
        [InlineData("'1','2','3'", "'", ",", "1", "2", "3")]
        [InlineData("'1'-'2'-'3'", "'", "-", "1", "2", "3")]
        [InlineData("' 1',' 2 ','3 '", "'", ",", " 1", " 2 ", "3 ")]
        public void ToStringWrappEqualWrappersTest(string expectedStr, string wrappValue, string delimiter, params string[] arrayCollection) => Assert.Equal(expectedStr, arrayCollection.ToList().ToStringWrapped(wrappValue, delimiter));

        [Theory(DisplayName = "To string wrapp")]
        [InlineData("'','',''", "'", "'", ",", "", "", "")]
        [InlineData("*',*',*'", "*", "'", ",", "", "", "")]
        [InlineData("'*,'*,'*", "'", "*", ",", "", "", "")]
        [InlineData("'',''", "'", "'", ",", "", null, "")]
        [InlineData("''", "'", "'", ",", "", null, null)]
        [InlineData(null, "'", "'", ",", null, null, null)]
        [InlineData("'abc','','def'", "'", "'", ",", "abc", "", "def")]
        [InlineData("'1','2','3'", "'", "'", ",", "1", "2", "3")]
        [InlineData("'1'-'2'-'3'", "'", "'", "-", "1", "2", "3")]
        [InlineData("' 1',' 2 ','3 '", "'", "'", ",", " 1", " 2 ", "3 ")]
        [InlineData("* 1',* 2 ',*3 '", "*", "'", ",", " 1", " 2 ", "3 ")]
        public void ToStringWrappTest(string expectedStr, string wrappValueBegin, string wrappValueEnd, string delimiter, params string[] arrayCollection) => Assert.Equal(expectedStr, arrayCollection.ToList().ToStringWrapped(wrappValueBegin, wrappValueEnd, delimiter));
    }
}