using System;

namespace Myframework.Libraries.Application.Options
{
    /// <summary>
    /// Classe base para options de background taks.
    /// </summary>
    public class BaseBackgroundTaskOptions
    {
        /// <summary>
        /// Intevalo entre as execuções da task.
        /// </summary>
        public TimeSpan Interval { get; set; }

        /// <summary>
        /// Indica se a task está habilitada ou não.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Indica se a task será chamada com await ou não.
        /// True: a task é chamada com await e somente após seu término começa a contar o período de intervalo indicado.
        /// False: a task é chamada em background e  o intervalo começa a contar a imediatamente, ou seja, a task pode 
        /// ser chamada novamente antes que a chamada anterior não tenha acabado.
        /// </summary>
        public bool AwaitTaskEndsToDelayInterval { get; set; }
    }
}