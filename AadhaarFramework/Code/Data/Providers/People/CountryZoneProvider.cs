using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Entity.People;
using AadhaarFramework.Code.Data.Providers.Common;
namespace AadhaarFramework.Code.Data.Providers.People
{
    /// <summary>
    /// Country zone data provider
    /// </summary>
    public class CountryZoneProvider : BaseProvider<CountryZone>
    {
        /// <summary>
        /// Soft delete method
        /// </summary>
        /// <param name="Entity"></param>
        public override void Delete(CountryZone Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                CountryZone Target = context.CountryZone.Single(b => b.Id == Entity.Id);
                context.CountryZone.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows
        /// </summary>
        /// <returns>List of rows</returns>
        public override IEnumerable<CountryZone> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.CountryZone.Where(b => b.IsDeleted == false).ToList();
            }
        }

        /// <summary>
        /// Return specific Country zone by Id
        /// </summary>
        /// <param name="pId">Key for the entity</param>
        /// <returns>Country zone</returns>
        public override CountryZone GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.CountryZone.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(CountryZone Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.Name, "Name");
            using (AadhaarContext context = new AadhaarContext())
            {
                CountryZone Exist = context.CountryZone.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    if (Entity.Id < 0) { Entity.Id = SequenceProvider.GetNextSequenceValueForCountryZone(); }
                    context.CountryZone.Add(Entity);
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
