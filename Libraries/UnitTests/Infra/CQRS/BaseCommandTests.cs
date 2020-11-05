using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Infra.CQRS.Commands;

namespace Infra.CQRS
{
    public class BaseCommandTests
    {
        //[Fact(DisplayName = "Auhtorization property is readonly but can be set by reflection")]
        //public void AAAA()
        //{
        //    var command = new CommandTest();
        //    string authorizationStr = Guid.NewGuid().ToString();

        //    string aut = new Guid(authorizationStr).ToString();
        //    PropertyInfo auhtorizationProperty = command.GetType().GetProperty(Constant.Authorization);
        //    auhtorizationProperty.SetValue(command, aut);

        //    Assert.Equal(aut, command.Authorization);
        //}


        public class CommandTest : BaseCommand<Result>
        {

        }
    }
}