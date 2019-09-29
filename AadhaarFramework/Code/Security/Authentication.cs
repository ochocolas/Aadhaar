using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Entity.Security;
using System.Data.Entity;
namespace AadhaarFramework.Code.Security
{
    /// <summary>
    /// Class for authentication on login
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Authenticates user and password
        /// </summary>
        /// <param name="pUser">User to authenticate</param>
        /// <param name="pPassword">password to authenticate</param>
        /// <returns></returns>
        public User Authenticate(string pUser, string pPassword)
        {
            User User = new User();
            using (AadhaarContext context = new AadhaarContext())
            {
                User = context.User.Where(b => b.UserName == pUser).Include("Roles").ToList().FirstOrDefault();
                if (User == null)
                    return null;

                if (User.IsBlocked)
                    throw new Exception("Usuario bloqueado");

                Type contextInfo2 = User.GetType();
                if (User == null)
                    return null;

                if (SimpleHash.CheckThisHashPlease(pPassword, User.Password))
                {
                    User.Password = string.Empty;
                    Type contextInfo = User.GetType();
                    AadhaarContext.UsuarioLogueado = User;
                    return User;
                }
            }
            return null;
        }

    }
}
