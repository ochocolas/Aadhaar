using System.Collections.Generic;
using System.Linq;
using AadhaarFramework.Code.Data.Providers.Common;
using AadhaarFramework.Code.Data.Entity.People;
using AadhaarFramework.Code.Data.Exceptions;
using System;
using System.Data.Entity;

namespace AadhaarFramework.Code.Data.Providers.People
{
    /// <summary>
    /// Person data provider
    /// </summary>
    public class PersonProvider : BaseProvider<Person>
    {
        /// <summary>
        /// Soft deletes an entity.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Delete(Person Entity)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                Person Target = context.Person.Single(b => b.Id == Entity.Id);
                context.Person.Remove(Target);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Return all rows of the entity
        /// </summary>
        /// <returns>Todos los objetos de {T}</returns>
        public override IEnumerable<Person> GetAll()
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Person.Where(b => b.IsDeleted == false).ToList();
            }
        }
        /// <summary>
        /// Returns the Entity by Id.
        /// </summary>
        /// <param name="pId"></param>
        /// <returns>{T}</returns>
        public override Person GetById(long pId)
        {
            using (AadhaarContext context = new AadhaarContext())
            {
                return context.Person.Where(b => b.Id == pId).Include("Photography").FirstOrDefault();
            }
        }
        /// <summary>
        /// Add the entity or update to the database.
        /// Run validations before save it.
        /// </summary>
        /// <param name="Entity">Base entity child.</param>
        public override void Save(Person Entity)
        {
            this.CheckIfIsNullOrEmpty(Entity.FirstName, "First name");
            this.CheckIfIsNullOrEmpty(Entity.MiddleName, "Middle name");
            this.CheckIfIsNullOrEmpty(Entity.LastName, "Last name");
            this.CheckIfIsZero(Entity.IdGender, "Gender");
            this.CheckIfIsZero(Entity.IdLanguage, "Language");
            this.CheckIfIsZero(Entity.IdReligion, "Religion");
            this.CheckIfIsZero(Entity.IdState, "State");

            if (Entity.Photography == null) { throw new BusinessRuleViolatedException("The photography is mandatory"); }
            if (!Entity.DoesItHaveAtLeastOneEye() & !Entity.DoesItHaveAtLeastOneFinger()) { throw new BusinessRuleViolatedException("The person that you are trying to enroll, need to have at least one eye or finger enrolled."); }

            if (CheckIfExists(Entity)) { throw new BusinessRuleViolatedException("The person that you are trying to enroll, already exist."); }


            using (AadhaarContext context = new AadhaarContext())
            {
                Person Exist = context.Person.SingleOrDefault(b => b.Id == Entity.Id);
                if (Exist == null)
                {
                    Entity.Id = this.GenerateID();//ya que no fue encontrado duplicado genera el ID
                    //Entity.Id = this.GenerateID(Entity);//ya que no fue encontrado duplicado genera el ID
                    context.Person.Add(Entity);
                }
                else
                {
                    Exist.CopyValuesFrom(Entity);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Verify via biometric data the authenticity of the Sent Person.
        /// </summary>
        /// <param name="Entity">The Person that needs to be verified.</param>
        /// <returns>true Existe, false No Existe</returns>
        public bool CheckIfExists(Person Entity)
        {

            EyeProvider EyeProvider = new EyeProvider();
            if (Entity == null) { return false; }
            if (EyeProvider.CheckIfExists(Entity.IrisLeftEye)) { return true; }
            if (EyeProvider.CheckIfExists(Entity.IrisRightEye)) { return true; }
            EyeProvider = null;

            FingerPrintProvider FingerPrintProvider = new FingerPrintProvider();
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintLeftHandThumb)) { return true; }
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintLeftHandIndex)) { return true; }
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintLeftHandMiddle)) { return true; }
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintLeftHandRing)) { return true; }
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintLeftHandPinky)) { return true; }

            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintRightHandThumb)) { return true; }
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintRightHandIndex)) { return true; }
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintRightHandMiddle)) { return true; }
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintRightHandRing)) { return true; }
            if (FingerPrintProvider.CheckIfExists(Entity.FingerPrintRightHandPinky)) { return true; }

            Entity.Photography.Id = SequenceProvider.GetNextSequenceValueForPhotography();
            //Agrega el ID del miembro biometrico a la entidad tambien.
            if (Entity.IrisLeftEye != null)
                Entity.IdIrisLeftEye = Entity.IrisLeftEye.Id = SequenceProvider.GetNextSequenceValueForEye();

            if (Entity.IrisRightEye != null)
                Entity.IdIrisRightEye = Entity.IrisRightEye.Id = SequenceProvider.GetNextSequenceValueForEye();

            if (Entity.FingerPrintLeftHandThumb != null)
                Entity.IdFingerPrintLeftHandThumb = Entity.FingerPrintLeftHandThumb.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintLeftHandIndex != null)
                Entity.IdFingerPrintLeftHandIndex = Entity.FingerPrintLeftHandIndex.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintLeftHandMiddle != null)
                Entity.IdFingerPrintLeftHandMiddle = Entity.FingerPrintLeftHandMiddle.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintLeftHandRing != null)
                Entity.IdFingerPrintLeftHandRing = Entity.FingerPrintLeftHandRing.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintLeftHandPinky != null)
                Entity.IdFingerPrintLeftHandPinky = Entity.FingerPrintLeftHandPinky.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintRightHandThumb != null)
                Entity.IdFingerPrintRightHandThumb = Entity.FingerPrintRightHandThumb.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintRightHandThumb != null)
                Entity.IdFingerPrintRightHandIndex = Entity.FingerPrintRightHandIndex.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintRightHandThumb != null)
                Entity.IdFingerPrintRightHandMiddle = Entity.FingerPrintRightHandMiddle.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintRightHandThumb != null)
                Entity.IdFingerPrintRightHandRing = Entity.FingerPrintRightHandRing.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();

            if (Entity.FingerPrintRightHandThumb != null)
                Entity.IdFingerPrintRightHandPinky = Entity.FingerPrintRightHandPinky.Id = SequenceProvider.GetNextSequenceValueForFingerPrint();
            return false;
        }

        /// <summary>
        /// Generate the UID, checks for duplicates
        /// </summary>
        /// <returns>UID generated</returns>
        public long GenerateID()
        {
            long CandidateID;
            Person Exist = null;
            do
            {
                Random rnd = new Random();
                int n1 = rnd.Next(1000000000, int.MaxValue);
                //string tempN;
                ////Se verifica si el numero generado no esta por debajo de los 12 digitos
                ////ya que es posible que se genere por ejemplo un 100
                ////complementaremos el numero para que tenga la longitud deseada
                //if (tempN.Length < 12)
                //{
                //    tempN = String.Concat("000000000000", tempN);
                //    tempN = tempN.Substring(12, pPerson.IdEnroller.ToString().Length);

                //}
                //tempN = String.Concat(pPerson.IdEnroller.ToString(), n1.ToString());
                //CandidateID= long.Parse(tempN);
                CandidateID = n1;
                Exist = this.GetById(CandidateID);
            } while (Exist != null);

            return CandidateID;
        }
    }
}
