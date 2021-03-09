using System.ComponentModel;

namespace Myframework.Libraries.Application.Security.Authorization
{
    public enum Roles
    {
        [Description("SuperAdministrator")] SuperAdministrator = 0,
        [Description("Administrator")] Administrator,

        [Description("Microservice")] Microservice,        
    }
}