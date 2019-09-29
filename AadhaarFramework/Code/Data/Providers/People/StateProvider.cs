using System.Collections.Generic;
using System.Linq;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Entity.People;
using AadhaarFramework.Code.Data.Exceptions;
namespace AadhaarFramework.Code.Data.Providers.People
{
    /// <summary>
    /// Country zone data provider
    /// </summary>
    public class StateProvider : BaseProvider<State>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(State Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                State Target = context.State.Single(b => b.Id == Entity.Id);
                context.State.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<State> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.State.Where(b => b.IsDeleted == false).ToList();
            }
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override State GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.State.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(State Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.Name, "Name");
            this.CheckIfIsNullOrEmpty(Entity.Capital, "Capital");
            this.CheckIfIsZero(Entity.Area, "Area");
            CountryZoneProvider countryZoneProvider = new CountryZoneProvider();
            LanguageProvider languageProvider = new LanguageProvider();
            if (countryZoneProvider.GetById(Entity.IdCountryZone) == null) { throw new BusinessRuleViolatedException("Select an item from the Country zone list"); }
            if (languageProvider.GetById(Entity.IdOfficialLanguage) == null) { throw new BusinessRuleViolatedException("Select an item from the Official language list"); }
            using (AadhaarContext context = new AadhaarContext())
            {
                State Exist = context.State.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    if (Entity.Id < 0) { Entity.Id = SequenceProvider.GetNextSequenceValueForState(); }
                    context.State.Add(Entity);
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
