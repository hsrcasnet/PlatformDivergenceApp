
using System;
using System.IO;

namespace PlatformDivergenceApp.Services
{
    public static class DatabaseAccess
    {
        public static string GetDatabaseFilePath()
        {
            const string filename = "TodoDatabase.db3";
            var libraryPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);

#if __ANDROID__
            libraryPath = Path.Combine(libraryPath, "Android");
#elif __IOS__
            libraryPath = Path.Combine(libraryPath, "..", "Library");
#endif
            var path = Path.Combine(libraryPath, filename);
            return path;
        }
    }
}
