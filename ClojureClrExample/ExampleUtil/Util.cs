namespace ExampleUtil
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;

    public static class Util
    {
        public static void StartMultiCoreJit(string name)
        {
#if NETFRAMEWORK
            try
            {
                var profileRoot = "Profile";

                Directory.CreateDirectory(profileRoot);

                System.Runtime.ProfileOptimization.SetProfileRoot(profileRoot);
                System.Runtime.ProfileOptimization.StartProfile(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on start multi core JIT: " + ex);
            }
#else
            Console.WriteLine("Multi core JIT only works for .NET framework");
#endif
        }

        public static string GetCallerFilePathDirectory([CallerFilePath] string filePath = "")
        {
            return Path.GetDirectoryName(filePath);
        }
    }
}
