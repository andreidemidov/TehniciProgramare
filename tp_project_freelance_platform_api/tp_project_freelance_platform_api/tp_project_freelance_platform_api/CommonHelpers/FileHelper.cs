using System.IO;

namespace Helpers
{
    public static class FileHelper
    {
        public static byte[] ReadData(Stream stream)
        {
            try
            {
                byte[] buffer = new byte[16 * 1024];

                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }

                    return ms.ToArray();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
