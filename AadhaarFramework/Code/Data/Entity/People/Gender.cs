using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Entity.Common;

namespace AadhaarFramework.Code.Data.Entity.People
{
    /// <summary>
    /// Gender class
    /// </summary>
    public class Gender : SimpleCatalogEntity
    {
        /// <summary>
        /// Initial catalog data.
        /// </summary>
        public static readonly string[] Genders = new string[] { "Male", "Female" };


    }
}
