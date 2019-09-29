
using System.ComponentModel.DataAnnotations;
using AadhaarFramework.Code.Security;
using AadhaarFramework.Code.Data.Entity.Common;
using System.Collections.Generic;

namespace AadhaarFramework.Code.Data.Entity.Security
{
    /// <summary>
    /// user entity for authentication.
    /// </summary>
    public class User:BaseEntity
    {
        /// <summary>
        /// User name
        /// </summary>
        [StringLength(NAME_LENGTH)]
        public string UserName { get; set; }
        /// <summary>
        /// Password encrypted.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User first name.
        /// </summary>
        [StringLength(NAME_LENGTH)]
        public string FirstName { get; set; }
        /// <summary>
        /// User middle name.
        /// </summary>
        [StringLength(NAME_LENGTH)]
        public string MiddleName { get; set; }
        /// <summary>
        /// User Last name
        /// </summary>
        [StringLength(NAME_LENGTH)]
        public string LastName { get; set; }
        /// <summary>
        /// User email.
        /// </summary>
        [StringLength(NAME_LENGTH)]
        public string Email { get; set; }
        /// <summary>
        /// Flag for more than 3 attempts, blocked user.
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Rol assigned to the user
        /// </summary>
        public List<Rol> Roles { get; set; } =  new List<Rol>();
        /// <summary>
        /// Hash the field password.
        /// </summary>
        public void hashThePassword()
        {
            Password = SimpleHash.HashThisPlease(Password);
        }

            
    }
}
