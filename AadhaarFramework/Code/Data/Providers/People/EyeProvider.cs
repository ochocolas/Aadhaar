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
    /// Eye data provider
    /// </summary>
    public class EyeProvider : BaseProvider<Eye>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(Eye Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Eye Target = context.Eye.Single(b => b.Id == Entity.Id);
                context.Eye.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<Eye> GetAll()
        {
            throw new BusinessRuleViolatedException("Use the method GetById instead");
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override Eye GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Eye.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(Eye Entity)
        {

            using (AadhaarContext context = new AadhaarContext())
            {
                Eye Exist = context.Eye.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    context.Eye.Add(Entity);
                }
                else
                {
                    throw new BusinessRuleViolatedException("Eye Iris cant be updated, use the method of PersonProvider.Save to update a Eye Iris");
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Check if the Iris exist in the database
        /// </summary>
        /// <param name="Eye">Eye data from the iris.</param>
        /// <returns>true Existe false No Existe</returns>
        public bool CheckIfExists(Eye Eye)
        {
            if (Eye == null)
                return false;
            using (AadhaarContext context = new AadhaarContext())
            {
                //Revisa que el Id no sea el mismo sobre el que se esta revisando
                //ya que queremos excluir tambi[en modificaciones del mismo registro
                Eye Exist = context.Eye.FirstOrDefault(b => b.Iris == Eye.Iris
                                                          & b.Id != Eye.Id
                                                          & b.IsDeleted == false);
                if (Exist != null)
                    return true;

                return false;
            }
        }
    }
}
