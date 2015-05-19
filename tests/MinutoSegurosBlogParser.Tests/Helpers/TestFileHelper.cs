using System;
using System.IO;
using System.Linq;

namespace MinutoSegurosBlogParser.Tests.Helpers
{
    internal static class TestFileHelper
    {
        public static string GetPath(string file)
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - 2));
            return Path.Combine(projectPath, "TestData", file);
        }
    }
}
