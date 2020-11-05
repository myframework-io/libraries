using System.Collections.Generic;

namespace Myframework.Libraries.Infra.Security
{
    public class SecurityOptions
    {
        public string AuthorityUrl { get; set; }
        public string ApiName { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientScope { get; set; }
        public List<string> AllowedRoles { get; set; }
    }
}