using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Entity.Process;
namespace AadhaarFramework.Code.Data.Providers.Process
{
    /// <summary>
    /// Enroller data provider
    /// </summary>
    public class EnrollerProvider:BaseProvider<Enroller>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(Enroller Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Enroller Target = context.Enroller.Single(b => b.Id == Entity.Id);
                context.Enroller.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<Enroller> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Enroller.Where(b => b.IsDeleted == false).ToList();
            }
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override Enroller GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Enroller.SingleOrDefault(b => b.Id == pId);
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(Enroller Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.Name, "Name");
            using (AadhaarContext context = new AadhaarContext())
            {
                
                Enroller Exist = context.Enroller.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    if (Entity.Id < 0) { Entity.Id = SequenceProvider.GetNextSequenceValueForEnroller(); }
                    context.Enroller.Add(Entity);
                }
                else
                {
                    if (!Entity.IsEnabled) { Entity.Token = String.Empty; }
                    //genera un "token" temporalmente, en la siguiente version se mejora la generacion de este token
                    if (Entity.IsEnabled & Entity.Token.Length==0 ) { Entity.Token = Guid.NewGuid().ToString(); }
                        Exist.CopyValuesFrom(Entity);
                }
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Returns true if the Enroller is valid
        /// </summary>
        /// <param name="token">token provided to enroller</param>
        /// <returns></returns>
        public bool IsValidEnroller(string token)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                //NO hace ninguna validaci[on
                //solo compara, en la siguiente version se hace todo el mecanismo de autenticacion de token
                Enroller Exist = context.Enroller.SingleOrDefault(b => b.Token.Equals(token));
                if (Exist == null) { return false; }
                return true;
            }

        }


    }
}
