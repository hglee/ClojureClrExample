namespace HelloScript
{
    using System;
    using clojure.lang;

    public class Program
    {
        private static void LoadFile()
        {
            // script file path
            var filePath = @"C:\Workspace\ClojureClrExample\ClojureClrExample\HelloScript\Resource\Script.clj";

            var loadFile = clojure.clr.api.Clojure.var("clojure.core", "load-file");
            loadFile.invoke(filePath);

            // 1. greet: calls function in script
            var func = clojure.clr.api.Clojure.var("ScriptNs", "greet");
            var greet = func.invoke("My Name");

            Console.WriteLine(greet);

            // 2. obj: object in script
            if (clojure.clr.api.Clojure.var("ScriptNs", "obj") is Var obj)
            {
                if (obj.get() is HelloClass cls)
                {
                    Console.WriteLine(cls.GetAnswer());
                }
            }

            // 3. obj2: create object by script
            var func2 = clojure.clr.api.Clojure.var("ScriptNs", "obj2");
            if (func2.invoke() is HelloClass obj2)
            {
                Console.WriteLine(obj2.GetAnswer());
            }
        }

        public static void Main(string[] args)
        {
            ExampleUtil.Util.StartMultiCoreJit("HelloScript.profile");

            LoadFile();
        }
    }
}
