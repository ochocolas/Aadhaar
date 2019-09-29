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
    /// Fingerprint data provider
    /// </summary>
    public class FingerPrintProvider : BaseProvider<FingerPrint>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(FingerPrint Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                FingerPrint Target = context.FingerPrint.Single(b => b.Id == Entity.Id);
                context.FingerPrint.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<FingerPrint> GetAll()
        {
            //Esto es porque no sirve de nada mostrar todas las huellas digitales
            //consume recurso, mejor solo seleccione la que desea previamente obtenida por 
            //filtros anteriores
            throw new BusinessRuleViolatedException("Use the method GetById instead");
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override FingerPrint GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.FingerPrint.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(FingerPrint Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                FingerPrint Exist = context.FingerPrint.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    context.FingerPrint.Add(Entity);
                }
                else
                {
                    throw new BusinessRuleViolatedException("Fingerprints cant be updated, use the method of PersonProvider.Save to update a Fingerprint");
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Check if the fingerprint exist in the sdatabase
        /// </summary>
        /// <param name="FingerPrint">Fingerprint</param>
        /// <returns>true Existe false No Existe</returns>
        public bool CheckIfExists(FingerPrint FingerPrint)
        {
            if (FingerPrint == null)
                return false;
            using (AadhaarContext context = new AadhaarContext())
            {
                //Revisa que el Id no sea el mismo sobre el que se esta revisando
                //ya que queremos excluir tambi[en modificaciones del mismo registro
                FingerPrint Exist = context.FingerPrint.FirstOrDefault(b => b.Finger == FingerPrint.Finger 
                                                                          & b.IsDeleted == false
                                                                          & b.Id != FingerPrint.Id);
                if (Exist != null)
                    return true;

                return false;
            }
        }
    }
}
