using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Application.Security.Authorization
{
    /// <summary>
    /// Classe estática para agrupar roles.
    /// </summary>
    public static class RolesGroupsOrganizer
    {
        private static readonly List<Roles> administrators = new List<Roles>
        {
            Roles.SuperAdministrator,
            Roles.Administrator
        };

        private static readonly List<Roles> productManagers = new List<Roles>
        {
            Roles.ProductManagerCCIH,
            Roles.ProductManagerIntegra,
            Roles.ProductManagerMonitor,
            Roles.ProductManagerSP,
            Roles.ProductManagerSupport,
            Roles.ProductManagerPublic
        };

        private static readonly List<Roles> supervisors = new List<Roles>
        {
            Roles.SupervisorCCIH,
            Roles.SupervisorIntegra,
            Roles.SupervisorMonitor,
            Roles.SupervisorSP
        };

        private static readonly List<Roles> supports = new List<Roles>
        {
            Roles.SupportLevel1,
            Roles.SupportLevel2,
            Roles.SupportLevel3
        };

        private static readonly List<Roles> microservices = new List<Roles>
        {
            Roles.Microservice
        };

        /// <summary>
        /// Une as de roles em uma lista, removendo duplicidades.
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static List<Roles> Join(params Roles[] roles)
        {
            if (roles == null)
                return new List<Roles>();

            var allRoles = new List<Roles>();

            foreach (Roles rolesIteration in roles)
            {
                allRoles.Add(rolesIteration);
            }

            return allRoles.Distinct().ToList();
        }

        /// <summary>
        /// Une todos as listas de roles em apenas uma, removendo duplicidades.
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static List<Roles> Join(params List<Roles>[] roles)
        {
            if (roles == null)
                return new List<Roles>();

            var allRoles = new List<Roles>();

            foreach (List<Roles> rolesIteration in roles)
            {
                allRoles.AddRange(rolesIteration);
            }

            return allRoles.Distinct().ToList();
        }

        /// <summary>
        /// Une todos as listas de roles de cada grupo em apenas uma, removendo duplicidades.
        /// </summary>
        /// <param name="groups"></param>
        /// <returns></returns>
        public static List<Roles> Join(params RolesGroups[] groups)
        {
            if (groups == null)
                return new List<Roles>();

            var allRoles = new List<Roles>();

            foreach (RolesGroups group in groups)
            {
                allRoles.AddRange(GetRolesFromGroup(group));
            }

            return allRoles.Distinct().ToList();
        }

        /// <summary>
        /// Retorna as roles de um grupo.
        /// </summary>
        /// <param name="rolesGroup"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Roles> GetRolesFromGroup(RolesGroups rolesGroup)
        {
            switch (rolesGroup)
            {
                case RolesGroups.Administrators:
                    return administrators;

                case RolesGroups.ProductManagers:
                    return productManagers;

                case RolesGroups.Supervisors:
                    return supervisors;

                case RolesGroups.Supports:
                    return supports;

                case RolesGroups.Microservices:
                    return microservices;

                default:
                    return new List<Roles>();
            }
        }
    }
}