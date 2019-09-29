using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AadhaarFramework.Code.Data.Entity.Common;
using AadhaarFramework.Code.Data.Entity.People;

namespace AadhaarFramework.Code.Data.Entity.People
{
    /// <summary>
    /// Photography entity for the Person entity
    /// </summary>
    public class Photography : BaseEntity
    {
        /// <summary>
        /// Photo byte data stored in database, for backup purposes.
        /// The infraestructure team just need to do backup on the database, yes, it will be larger
        /// but it just need to focus on one backup, not multiple file servers.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Provides test functionallity for generate a random image.
        /// </summary>
        /// <returns>Return a random array of bytes</returns>
        public byte[] GenerateTestPhotography()
        {
            //int width = 640, height = 320;
            int width = 120, height = 120;

            //bitmap
            Bitmap bmp = new Bitmap(width, height);

            //random number
            Random rand = new Random();

            //create random pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //generate random ARGB value
                    int a = rand.Next(256);
                    int r = rand.Next(256);
                    int g = rand.Next(256);
                    int b = rand.Next(256);

                    //set ARGB value
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            using (var stream = new MemoryStream())
            {
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }

        }
    }
}
