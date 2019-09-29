
using AadhaarFramework.Code.Data.Entity.Common;
using System.ComponentModel.DataAnnotations;

namespace AadhaarFramework.Code.Data.Entity.Process
{
    /// <summary>
    /// Enroller entity... entity
    /// </summary>
    public class Enroller:SimpleCatalogEntity
    {
        /// <summary>
        /// Test data
        /// </summary>
        public static readonly string[] Enrollers = new string[] {
            "{0}"
        ,"Bank of {0}"
        ,"{0}, HQ"
        ,"{0} street"
        ,"{0} Oil Company"
            ,"{0} Gas Company"
            ,"{0} Food company"
            ,"Goverment Agency, {0} zone"
            ,"{0} Camp"
        };
        /// <summary>
        /// A flag for enable the syncronization, if something is wrong with the Enroller, this will "ban" it.
        /// </summary>
        public bool IsEnabled { get; set; } = false;

        /// <summary>
        /// Authentication token generated.
        /// </summary>
        [StringLength(500)]
        public string Token { get; set; }
    }
}
