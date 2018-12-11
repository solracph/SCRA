using System;
using System.IO;

namespace SCRA.Common.Utilities
{
    public static class LogHelper
    {
        public static void Exception(Exception exception)
        {
            string exceptionFilePath = GetFilePath();

            using (StreamWriter writer = new StreamWriter(exceptionFilePath, true))
            {
                Exception e = exception;

                while (e != null)
                {
                    writer.WriteLine(e.Message);
                    writer.WriteLine(e.StackTrace);

                    e = e.InnerException;
                }

                writer.WriteLine();
            }
        }

        public static void WriteLog(string message)
        {
            string exceptionFilePath = GetFilePath();

            using (StreamWriter writer = new StreamWriter(exceptionFilePath, true))
            {
                writer.WriteLine(message);
                writer.WriteLine();
            }
        }

        public static string GetFilePath()
        {
            string datePath = string.Format("{0}{1}", Settings.LogPath, "Errors\\");

            if (!Directory.Exists(datePath))
            {
                Directory.CreateDirectory(datePath);
            }

            return string.Format("{0}{1}.txt", datePath, DateTime.Now.ToString("yyyy-MM-dd"));
        }
    }
}
