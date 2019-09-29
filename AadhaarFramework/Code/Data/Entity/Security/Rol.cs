
using AadhaarFramework.Code.Data.Entity.Common;
using System.Collections.Generic;
using AadhaarFramework.Code.Data.Entity.ASystem;
namespace AadhaarFramework.Code.Data.Entity.Security
{
    /// <summary>
    /// Rol definition entity
    /// </summary>
    public class Rol:SimpleCatalogEntity
    {
        /// <summary>
        /// Users assigned to the rol.
        /// </summary>
        public List<User> Usuarios { get; set; } = new List<User>();
        //public List<MenuAadhaar> Menu { get; set; } = new List<MenuAadhaar>();
    }
}
