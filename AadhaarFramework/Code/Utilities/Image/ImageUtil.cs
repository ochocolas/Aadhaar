using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AadhaarFramework.Code.Utilities.Image
{
    /// <summary>
    /// General Image convertion utility
    /// </summary>
    public class ImageUtil
    {
        /// <summary>
        ///     ''' Converts the Image File to array of Bytes
        ///     ''' </summary>
        ///     ''' <param name="ImageFilePath">The path of the image file</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public static byte[] ConvertImageFiletoBytes(string ImageFilePath)
        {
            byte[] _tempByte = null;
            if (string.IsNullOrEmpty(ImageFilePath) == true)
            {
                throw new ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath");
                
            }
            try
            {
                System.IO.FileInfo _fileInfo = new System.IO.FileInfo(ImageFilePath);
                long _NumBytes = _fileInfo.Length;
                System.IO.FileStream _FStream = new System.IO.FileStream(ImageFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FStream);
                _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes));
                _fileInfo = null;
                _NumBytes = 0;
                _FStream.Close();
                _FStream.Dispose();
                _BinaryReader.Close();
                return _tempByte;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///     ''' Converts array of Bytes to Image File
        ///     ''' </summary>
        ///     ''' <param name="ImageData">The array of bytes which contains image binary data</param>
        ///     ''' <param name="FilePath">The destination file path.</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public bool ConvertBytesToImageFile(byte[] ImageData, string FilePath)
        {
            if (ImageData ==null)
                return false;
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(FilePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
                bw.Write(ImageData);
                bw.Flush();
                bw.Close();
                fs.Close();
                bw = null;
                fs.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        ///     ''' Converts array of bytes to Memoey Stream
        ///     ''' </summary>
        ///     ''' <param name="ImageData">The array of bytes which contains image binary data</param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public System.IO.MemoryStream ConvertBytesToMemoryStream(byte[] ImageData)
        {
            try
            {
                if (ImageData == null)
                    return null;
                return new System.IO.MemoryStream(ImageData);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        ///     ''' Converts the Image File to Memory Stream
        ///     ''' </summary>
        ///     ''' <param name="ImageFilePath"></param>
        ///     ''' <returns></returns>
        ///     ''' <remarks></remarks>
        public System.IO.MemoryStream ConvertImageFiletoMemoryStream(string ImageFilePath)
        {
            if (string.IsNullOrEmpty(ImageFilePath) == true)
                return null;
            return ConvertBytesToMemoryStream(ConvertImageFiletoBytes(ImageFilePath));
        }
        /// <summary>
        /// Converts the image from bytes to Image object
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static System.Drawing.Image ConvertBytesToImage(byte[] byteArray)
        {
            using (MemoryStream memstr = new MemoryStream(byteArray))
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(memstr);
                return img;
            }
            
        }
    }
}
