namespace HelloInterface
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            ExampleUtil.Util.StartMultiCoreJit("HelloInterface.profile");

            LoadFile();
        }

        private static void LoadFile()
        {
            var filePath = Path.Combine(ExampleUtil.Util.GetCallerFilePathDirectory(), "Resource", "Script.clj");

            var loadFile = clojure.clr.api.Clojure.var("clojure.core", "load-file");
            loadFile.invoke(filePath);

            // 1. create implement 1
            var baseObj = (IGreet) clojure.clr.api.Clojure.var("ScriptNs", "create-impl1")
                .invoke();

            Console.WriteLine(baseObj.GreetMessage);
            Console.WriteLine(baseObj.Greet());
            Console.WriteLine(baseObj.GetType());
            Console.WriteLine();

            // 2. create implement 2
            var subObj = (IGreet)clojure.clr.api.Clojure.var("ScriptNs", "create-impl2")
                .invoke();

            Console.WriteLine(subObj.GreetMessage);
            Console.WriteLine(subObj.Greet());
            Console.WriteLine(subObj.GetType());
        }
    }
}
