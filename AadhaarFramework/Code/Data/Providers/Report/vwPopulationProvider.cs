using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Entity.Report;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Providers.Report;
namespace AadhaarFramework.Code.Data.Providers.Report
{
    /// <summary>
    /// Country zone data provider
    /// </summary>
    public class vwPopulationProvider : BaseProvider<vwPopulation>
    {
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="Entity"></param>
        public override void Delete(vwPopulation Entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<vwPopulation> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.vwPopulation.ToList();
            }
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public override vwPopulation GetById(long pId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="Entity"></param>
        public override void Save(vwPopulation Entity)
        {
            throw new NotImplementedException();
        }
    }
}
