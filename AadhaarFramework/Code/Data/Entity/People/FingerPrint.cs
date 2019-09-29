
using AadhaarFramework.Code.Data.Entity.Common;
using System;

namespace AadhaarFramework.Code.Data.Entity.People
{
    /// <summary>
    /// Fingerprint biometric data
    /// </summary>
    public class FingerPrint:BaseEntity
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public FingerPrint()
        {

        }
        /// <summary>
        /// GEnerate test datata for a fingerprint
        /// </summary>
        /// <param name="GenerateFinger"></param>
        public FingerPrint(bool GenerateFinger)
        {
            if (GenerateFinger)
                Finger = this.GenerateTestFinger();
        }
        /// <summary>
        /// Finger data, it will be simulated as a gui string because, in real life data is  a long string.
        /// </summary>
        public string Finger { get; set; }

        /// <summary>
        /// Generate test fingerprint data.
        /// </summary>
        /// <returns></returns>
        public string GenerateTestFinger()
        {
            return String.Concat(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()).Replace("-", String.Empty);
        }
    }
}
