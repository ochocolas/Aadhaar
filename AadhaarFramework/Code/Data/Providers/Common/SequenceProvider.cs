using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Exceptions;
namespace AadhaarFramework.Code.Data.Providers.Common
{
    /// <summary>
    /// Manages the Id generation via Sequences from the database.
    /// </summary>
    public class SequenceProvider
    {
        /// <summary>
        /// Query statement for sequence recovery.
        /// </summary>
        private const string NEXT_VALUE_FOR = "SELECT NEXT VALUE FOR dbo.s{0} As Id";
        /// <summary>
        /// Get the Next Sequence value from the specified Entity.
        /// </summary>
        /// <param name="EntityName">Entity name</param>
        /// <returns>Next sequence value</returns>
        private static long GetNextSequenceValue(string EntityName)
        {
            long NextValue;
            using (AadhaarContext context = new AadhaarContext())
            {
                NextValue = context.Database.SqlQuery<long>(string.Format(NEXT_VALUE_FOR, EntityName)).FirstOrDefault();
            }

            return NextValue;
        }

        /// <summary>
        /// Return the sequence for the entity CountryZone
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForCountryZone(){  return GetNextSequenceValue("CountryZone");}
        /// <summary>
        /// Return the sequence for the entity Eye
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForEye() { return GetNextSequenceValue("Eye"); }
        /// <summary>
        /// Return the sequence for the entity Fingerprint
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForFingerPrint(){  return GetNextSequenceValue("FingerPrint");}
        /// <summary>
        /// Return the sequence for the entity Gender
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForGender(){  return GetNextSequenceValue("Gender");}
        /// <summary>
        /// Return the sequence for the entity Language
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForLanguage(){  return GetNextSequenceValue("Language");}
        /// <summary>
        /// Return the sequence for the entity Person
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForPerson(){  return GetNextSequenceValue("Person");}
        /// <summary>
        /// Return the sequence for the entity Photography
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForPhotography(){  return GetNextSequenceValue("Photography");}
        /// <summary>
        /// Return the sequence for the entity Religion
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForReligion(){  return GetNextSequenceValue("Religion");}
        /// <summary>
        /// Return the sequence for the entity State
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForState(){  return GetNextSequenceValue("State");}
        /// <summary>
        /// Return the sequence for the entity Enroller
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForEnroller(){  return GetNextSequenceValue("Enroller");}
        /// <summary>
        /// Return the sequence for the entity Rol
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForRol(){  return GetNextSequenceValue("Rol");}
        /// <summary>
        /// Return the sequence for the entity User
        /// </summary>
        /// <returns>Next Sequence value</returns>
        public static long GetNextSequenceValueForUser(){  return GetNextSequenceValue("User");}
        

    }
}
