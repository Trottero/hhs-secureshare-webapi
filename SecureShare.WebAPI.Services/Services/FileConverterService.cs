using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecureShare.WebAPI.Services.Services
{
    public class FileConverterService
    {
        public static string ConvertFileToBase64(string path)
        {
            var bytes = File.ReadAllBytes(
                "https://securesharedevstorage.blob.core.windows.net/files/5b9cf7ee-7a1a-4cce-918a-b740bda9dfdf");


            return Convert.ToBase64String(bytes);
        }

        public static string ConvertFileToBase64(FileStream fileStream)
        {
            var array = new byte[fileStream.Length];
            fileStream.Read(array, 0, array.Length);
            return Convert.ToBase64String(array);
        }
        public static FileStream ConvertBase64ToFileStream(string base64)
        {

            string tempFilePath = Path.GetTempFileName();

            FileStream fileStream = new FileStream(tempFilePath, FileMode.Create);

            var bytearray = Convert.FromBase64String(base64);
            fileStream.Write(bytearray, 0, bytearray.Length);
            fileStream.Close();
            return new FileStream(tempFilePath, FileMode.Open);
        }
    }
}
