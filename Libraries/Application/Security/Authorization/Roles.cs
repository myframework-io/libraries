using System.ComponentModel;

namespace Myframework.Libraries.Application.Security.Authorization
{
    public enum Roles
    {
        [Description("SuperAdministrator")] SuperAdministrator = 0,
        [Description("Administrator")] Administrator,

        [Description("Product Manager - CCIH")] ProductManagerCCIH,
        [Description("Product Manager - Integra")] ProductManagerIntegra,
        [Description("Product Manager - Monitor")] ProductManagerMonitor,
        [Description("Product Manager - SP")] ProductManagerSP,
        [Description("Product Manager - Support")] ProductManagerSupport,
        [Description("Product Manager - Public")] ProductManagerPublic,

        [Description("Stakeholder")] Stakeholder,

        [Description("Supervisor - CCIH")] SupervisorCCIH,
        [Description("Supervisor - Integra")] SupervisorIntegra,
        [Description("Supervisor - Monitor")] SupervisorMonitor,
        [Description("Supervisor - SP")] SupervisorSP,

        [Description("SupportLevel1")] SupportLevel1,
        [Description("SupportLevel2")] SupportLevel2,
        [Description("SupportLevel3")] SupportLevel3,

        [Description("Surveillance")] Surveillance,
        [Description("Surveillance - Beds")] SurveillanceBeds,

        [Description("Translator")] Translator,

        [Description("Microservice")] Microservice,        
    }
}