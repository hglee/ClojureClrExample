namespace HelloSubClass
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            ExampleUtil.Util.StartMultiCoreJit("HelloSubClass.profile");

            LoadFile();
        }

        private static void LoadFile()
        {
            var filePath = @"C:\Workspace\ClojureClrExample\ClojureClrExample\HelloSubClass\Resource\Script.clj";

            var loadFile = clojure.clr.api.Clojure.var("clojure.core", "load-file");
            loadFile.invoke(filePath);

            // 1. create base class
            var baseObj = (BaseClass) clojure.clr.api.Clojure.var("ScriptNs", "create-base")
                .invoke();

            Console.WriteLine(baseObj.StringProperty);
            Console.WriteLine(baseObj.Method1());

            // 2. create sub class
            var subObj = (BaseClass)clojure.clr.api.Clojure.var("ScriptNs", "create-sub")
                .invoke();

            Console.WriteLine(subObj.StringProperty);
            Console.WriteLine(subObj.Method1());
        }
    }
}
