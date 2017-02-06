using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NameReorder
{
    public class PathUtil
    {
        public static string GetAssemblyPath()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return Path.GetDirectoryName(assembly.FullName);
        }

        public static char GetSeperator()
        {
            return Path.DirectorySeparatorChar;
        }

        public static string GetFileName(string file)
        {
            return Path.GetFileNameWithoutExtension(file);
        }

        public static string GetFileExtension(string file)
        {
            return Path.GetExtension(file);
        }

        public static bool IsExists(string file)
        {
            return File.Exists(file);
        }

        public static string GetDir(string file)
        {
            return Path.GetDirectoryName(file);
        }
    }
}
