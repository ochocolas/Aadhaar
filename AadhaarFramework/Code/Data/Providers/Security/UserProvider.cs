using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Entity.Security;
namespace AadhaarFramework.Code.Data.Providers.Security
{
    /// <summary>
    /// User provider
    /// </summary>
    public class UserProvider : BaseProvider<User>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(User Entity)
        {
            using (AadhaarContext context= new AadhaarContext())
            {
                User Target = context.User.SingleOrDefault(b => b.Id == Entity.Id);
                context.User.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<User> GetAll()
        {
            using(AadhaarContext context = new AadhaarContext())
            {
                return context.User.Where(b => b.IsDeleted == false).ToList();
            }
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override User GetById(long pId)
        {
         using(AadhaarContext context =new AadhaarContext())
            {
                return context.User.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(User Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.UserName,"UserName");
            this.CheckIfIsNullOrEmpty(Entity.Password, "Password");
            this.CheckIfIsNullOrEmpty(Entity.FirstName, "First Name");
            this.CheckIfIsNullOrEmpty(Entity.LastName, "Last Name");

            Entity.hashThePassword();
            using(AadhaarContext context = new AadhaarContext())
            {
                User Exist = context.User.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    context.User.Add(Entity);
                }
                else
                {
                    Exist.CopyValuesFrom(Entity);
                }
                context.SaveChanges();
            }



        }
    }
}
