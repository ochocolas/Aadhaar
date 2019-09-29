
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AadhaarFramework.Code.Data.Entity.Common
{
    /// <summary>
    /// Base class for simple catalog entities.
    /// Just for simplify and guarantie the name field.
    /// </summary>
    public class SimpleCatalogEntity:BaseEntity
    {
        /// <summary>
        /// Name of the simple catalog entity
        /// </summary>
        [Required,StringLength(NAME_LENGTH), Column(Order = 3)]
        public string Name { get; set; }
    }
}
