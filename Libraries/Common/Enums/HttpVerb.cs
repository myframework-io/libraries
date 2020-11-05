using System.ComponentModel;

namespace Myframework.Libraries.Common.Enums
{
    /// <summary>
    /// Enumerador para representar os verbos/métodos HTTP.
    /// </summary>
    public enum HttpVerb
    {
        /// <summary></summary>
        [Description("Get")] Get = 1,

        /// <summary></summary>
        [Description("Post")] Post = 2,

        /// <summary></summary>
        [Description("Put")] Put = 4,

        /// <summary></summary>
        [Description("Delete")] Delete = 8,

        /// <summary></summary>
        [Description("Head")] Head = 16,

        /// <summary></summary>
        [Description("Patch")] Patch = 32,

        /// <summary></summary>
        [Description("Options")] Options = 64
    }
}