using System.Collections.Generic;
using System.Linq;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Entity.Security;
namespace AadhaarFramework.Code.Data.Providers.Security
{
    /// <summary>
    /// Rol provider
    /// </summary>
    public class RolProvider : BaseProvider<Rol>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(Rol Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Rol Target = context.Rol.Single(b => b.Id == Entity.Id);
                context.Rol.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<Rol> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Rol.Where(b => b.IsDeleted == false).ToList();
            }
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override Rol GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Rol.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(Rol Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.Name, "Name");
            using (AadhaarContext context = new AadhaarContext())
            {
                Rol Exist = context.Rol.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    context.Rol.Add(Entity);
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
