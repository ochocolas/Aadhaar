using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AadhaarFramework.Code.Data.Exceptions
{
    /// <summary>
    /// Exception class for Business rules.
    /// </summary>
   public class BusinessRuleViolatedException:Exception
    {
        

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessRuleViolatedException()
            : base()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Message"></param>
        public BusinessRuleViolatedException(string Message)
            : base(Message)
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public BusinessRuleViolatedException(string message, Exception innerException)
            : base(message,innerException)
        {

        }
    }
}
