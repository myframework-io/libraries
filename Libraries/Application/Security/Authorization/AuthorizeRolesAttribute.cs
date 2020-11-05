using Myframework.Libraries.Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Application.Security.Authorization
{
    /// <summary>
    /// Atributo que herda de "AuthorizeAttribute" e transforma as roles no formato enum para string, que é usado pela classe base.
    /// </summary>
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute() => Initialize(null);

        public AuthorizeRolesAttribute(params RolesGroups[] rolesGroups)
            : this("", rolesGroups)
        {

        }

        public AuthorizeRolesAttribute(string roles, params RolesGroups[] rolesGroups)
        {
            Roles = roles ?? "";

            if (rolesGroups == null || !rolesGroups.Any())
            {
                Initialize(null);
                return;
            }

            var rolesList = new List<Roles>();

            foreach (RolesGroups group in rolesGroups)
            {
                List<Roles> groupRoles = RolesGroupsOrganizer.Join(RolesGroupsOrganizer.GetRolesFromGroup(group).ToArray());
                rolesList = RolesGroupsOrganizer.Join(rolesList, groupRoles);
            }

            Initialize(rolesList);
        }

        public AuthorizeRolesAttribute(params Roles[] roles) => Initialize(roles?.ToList());

        private void Initialize(List<Roles> roles)
        {
            if (roles == null || !roles.Any())
                return;

            string rolesStr = "";

            foreach (Roles role in roles)
            {
                rolesStr += $"{role.GetDescription()},";
            }

            if (rolesStr.EndsWith(","))
                rolesStr = rolesStr.Substring(0, rolesStr.Length - 1);

            if (string.IsNullOrWhiteSpace(Roles))
                Roles = rolesStr;
            else
                Roles += "," + rolesStr;
        }
    }
}