using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AadhaarFramework.Code.ASystem
{
    /// <summary>
    /// An entity for message return for logging pruporses.
    /// You should declare a list of AadhaarLog
    /// </summary>
    public class AadhaarLog
    {
        /// <summary>
        /// Types of logs
        /// </summary>
        public enum LogType
        {
            ERROR,
            WARNING,
            INFORMATIVE
        }
        /// <summary>
        /// Id Key for the list
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Type of Log
        /// </summary>
        public LogType Type { get; set; }
        /// <summary>
        /// when the log was generated
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// Description of the log, it could be an error or a informative message like a confirmation of success operation.
        /// </summary>
        public string Message { get; set; }

    }
}
