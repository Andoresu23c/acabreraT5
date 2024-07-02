using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acabreraS5.Utils
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string path)
        {
            return Path.Combine(FileSystem.AppDataDirectory, path);
        }
    }
}
