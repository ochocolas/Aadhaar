using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Entity.People;
namespace AadhaarFramework.Code.Data.Providers.People
{
    /// <summary>
    /// Gender data provider
    /// </summary>
    public class GenderProvider : BaseProvider<Gender>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(Gender Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Gender Target = context.Gender.Single(b => b.Id == Entity.Id);
                context.Gender.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<Gender> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Gender.Where(b => b.IsDeleted == false).ToList();
            }
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override Gender GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Gender.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(Gender Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.Name, "Name");
            using (AadhaarContext context = new AadhaarContext())
            {
                Gender Exist = context.Gender.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    if (Entity.Id < 0) { Entity.Id = SequenceProvider.GetNextSequenceValueForGender(); }
                    context.Gender.Add(Entity);
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
