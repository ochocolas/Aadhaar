using System.Collections.Generic;
using System.Linq;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Entity.People;
using AadhaarFramework.Code.Data.Exceptions;
namespace AadhaarFramework.Code.Data.Providers.People
{
    /// <summary>
    /// Photography data provider
    /// </summary>
    public class PhotographyProvider : BaseProvider<Photography>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(Photography Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Photography Target = context.Photography.Single(b => b.Id == Entity.Id);
                context.Photography.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<Photography> GetAll()
        {
            //Esto es porque no sirve de nada mostrar todas las fotografias
            //consume recurso, mejor solo seleccione la que desea previamente obtenida por 
            //filtros anteriores
            throw new BusinessRuleViolatedException("Use the method GetById instead");
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override Photography GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Photography.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(Photography Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Photography Exist = context.Photography.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    context.Photography.Add(Entity);
                }
                else
                {
                    throw new BusinessRuleViolatedException("Photographies cant be updated, use the method of PersonProvider.Save to update a photography");
                }
                context.SaveChanges();
            }
        }


    }
}
