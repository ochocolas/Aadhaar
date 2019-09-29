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
    /// Religion data provider
    /// </summary>
    public class ReligionProvider : BaseProvider<Religion>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(Religion Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Religion Target = context.Religion.Single(b => b.Id == Entity.Id);
                context.Religion.Remove(Target);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<Religion> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                List<Religion> res = context.Religion.Where(b => b.IsDeleted == false).ToList();
                return res;
            }
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override Religion GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Religion.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(Religion Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.Name, "Name");
            using (AadhaarContext context = new AadhaarContext())
            {
                Religion Exist = context.Religion.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    if (Entity.Id < 0) { Entity.Id = SequenceProvider.GetNextSequenceValueForReligion(); }
                    context.Religion.Add(Entity);
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
