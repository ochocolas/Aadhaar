using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Entity.People;
using AadhaarFramework.Code.Data.Exceptions;
namespace AadhaarFramework.Code.Data.Providers.People
{
    /// <summary>
    /// Delete data provider
    /// </summary>
    public class LanguageProvider : BaseProvider<Language>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(Language Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Language Target = context.Language.Single(b => b.Id == Entity.Id);
                context.Language.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<Language> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Language.Where(b => b.IsDeleted == false).ToList();
            }
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override Language GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Language.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(Language Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.Name, "Name");
            using (AadhaarContext context = new AadhaarContext())
            {
                Language Exist = context.Language.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    if (Entity.Id < 0) { Entity.Id = SequenceProvider.GetNextSequenceValueForLanguage(); }
                    context.Language.Add(Entity);
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
