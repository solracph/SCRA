using System.IO;

namespace SCRA.Common.Utilities
{
    public static class FileHelper
    {
        public static byte[] GetContent(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (MemoryStream contentStream = new MemoryStream())
                    {
                        fileStream.CopyTo(contentStream);

                        return contentStream.ToArray();
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
