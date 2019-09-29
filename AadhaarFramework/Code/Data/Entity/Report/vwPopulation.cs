using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AadhaarFramework.Code.Data.Entity.Report
{
    /// <summary>
    /// A class mapped to a view in the database view vwPopulation
    /// </summary>
    [Table("vwPopulation")]
    public class vwPopulation
    {
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public bool IsDesceased { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public bool IsDuplicated { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public Nullable<DateTime> ModifyDate { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string ModifyBy { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public int CorrectionIndex { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public bool IsHandicapped { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public decimal Latitud { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public decimal Longitud { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public int Population { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string CountryZoneName { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string GenderName { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string ReligionName { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string EnrollerName { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public bool EnrollerIsEnabled { get; set; }
        /// <summary>
        /// Field mapped to the database view vwPopulation
        /// </summary>
        public string LanguageName { get; set; }
    }
}
