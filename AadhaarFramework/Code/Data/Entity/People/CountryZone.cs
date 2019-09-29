using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Entity.Common;



namespace AadhaarFramework.Code.Data.Entity.People
{
    /// <summary>
    /// Country zones
    /// </summary>
    public class CountryZone:SimpleCatalogEntity
    {
        /// <summary>
        /// Initial catalog data
        /// </summary>
        public static readonly string[] CountryZones = new string[] { "Northen", "Southern", "Wester", "Eastern", "North-Eastern", "North-Wester", "Central", "South-West", "South-East" };
    }
}
