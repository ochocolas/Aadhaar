
using AadhaarFramework.Code.Data.Entity.Common;


namespace AadhaarFramework.Code.Data.Entity.People
{
    /// <summary>
    /// Religion for person
    /// </summary>
    public class Religion:SimpleCatalogEntity
    {
        /// <summary>
        /// Initial catalog data
        /// </summary>
        public static readonly string[] Religions = new string[] { "Buddhism", "Christianity", "Hinduism", "Islam", "Jainism", "Sikhism", "Zoroastrianism", "Other" };
    }
}
