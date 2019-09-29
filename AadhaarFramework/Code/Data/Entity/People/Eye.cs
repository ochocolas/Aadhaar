using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AadhaarFramework.Code.Data.Entity.Common;
namespace AadhaarFramework.Code.Data.Entity.People
{
    /// <summary>
    /// Entity for Biometric Eye information
    /// </summary>
    public class Eye:BaseEntity
    {
        /// <summary>
        /// Return the Test Iris data for testing purpose
        /// </summary>
        private string _TestIris = String.Empty;
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Eye()
        {

        }
        /// <summary>
        /// Constructor that generate and set a random iris data
        /// </summary>
        /// <param name="GenerateEye"></param>
        public Eye(bool GenerateEye)
        {
            this.Iris = this.GenerateTestIris();
        }
        /// <summary>
        /// Iris information, this is set as a GUI string, because in real life is a long string.
        /// </summary>
        public string Iris { get; set; }
        /// <summary>
        /// Generate guis strings to simulate Iris data.
        /// </summary>
        /// <returns>Return test iris data.</returns>
        public string GenerateTestIris()
        {
            return String.Concat(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()).Replace("-",String.Empty);
        }
        /// <summary>
        /// Return the iris data as the object string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!_TestIris.Equals(String.Empty))
                _TestIris = this.GenerateTestIris();

            return _TestIris;
            //return base.ToString();
        }

    }
}
