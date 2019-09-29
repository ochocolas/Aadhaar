using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Exceptions;
namespace AadhaarFramework.Code.Data.Providers.Common
{
    /// <summary>
    /// Base class for all the application and business rules.
    /// </summary>
    /// <typeparam name="T">Entity that wraps the whole meaning of the Provider defined in another class</typeparam>
    public abstract class BaseProvider<T>
    {

        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public abstract void Delete(T Entity);
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public abstract IEnumerable<T> GetAll();
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public abstract T GetById(long pId);
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public abstract void Save(T Entity);
        /// <summary>
        /// Base funcionallity for check values and throw BusinessRuleViolatedException.
        /// </summary>
        /// <param name="pValor">Valor that needs to check.</param>
        /// <param name="pFieldName">Field name</param>
        protected void CheckIfIsZero(long pValor, string pFieldName)
        {
            if (pValor == 0) { throw new BusinessRuleViolatedException(String.Format("{0} can't be 0", pFieldName));}

        }
        /// <summary>
        /// Base funcionallity for check values and throw BusinessRuleViolatedException.
        /// </summary>
        /// <param name="pValor">Valor that needs to check.</param>
        /// <param name="pFieldName">Field name</param>
        protected void CheckIfIsZero(decimal pValor, string pFieldName)
        {
            if (pValor == 0) { throw new BusinessRuleViolatedException(String.Format("{0} can't be 0.0", pFieldName)); }

        }
        /// <summary>
        /// Base funcionallity for check values and throw BusinessRuleViolatedException.
        /// </summary>
        /// <param name="pValor">Valor that needs to check.</param>
        /// <param name="pFieldName">Field name</param>
        protected void CheckIfIsNullOrEmpty(string pValor, string pFieldName)
        {
            if (pValor == null || pValor.Length == 0)
                throw new BusinessRuleViolatedException(String.Format("{0} is mandatory.", pFieldName));
        }

    }
}
