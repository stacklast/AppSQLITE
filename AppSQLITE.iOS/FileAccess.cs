using System;

namespace AppSQLITE.iOS
{
    public class FileAccess
    {
        public static String GetLocalFilePath(string filename)
        {

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return System.IO.Path.Combine(path, filename);
        }
    }
}