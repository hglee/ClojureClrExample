namespace HelloSequence
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using clojure.lang;

    public class Program
    {
        public static void Main(string[] args)
        {
            ExampleUtil.Util.StartMultiCoreJit("HelloSequence.profile");

            LoadFile();
        }

        private static void LoadFile()
        {
            var filePath = @"C:\Workspace\ClojureClrExample\ClojureClrExample\HelloSequence\Resource\Script.clj";

            var loadFile = clojure.clr.api.Clojure.var("clojure.core", "load-file");
            loadFile.invoke(filePath);

            Console.WriteLine("1. send sequence to script");

            clojure.clr.api.Clojure.var("ScriptNs", "recv-bigseq").invoke(Generate());

            // Don't try this for big sequence, see next.
            Console.WriteLine("2. receive sequence from script. ");

            if (clojure.clr.api.Clojure.var("ScriptNs", "short-seq").invoke() is IEnumerable<object> seq)
            {
                foreach (var v in seq.Skip(123).Take(3))
                {
                    Console.WriteLine(v);
                }
            }

            // Don't use LINQ directly, need trick for memory usage.
            Console.WriteLine("3. receive infinite sequence from script.");

            if (clojure.clr.api.Clojure.var("ScriptNs", "big-seq").invoke() is Iterate iter)
            {
                foreach (var v in SkipIterate(iter, 123456789).Take(3))
                {
                    Console.WriteLine(v);
                }
            }
        }

        /// <summary>
        /// Generate numbers
        /// </summary>
        /// <returns>Sequence of number.</returns>
        private static IEnumerable<long> Generate()
        {
            long v = 0;

            while (true)
            {
                yield return v++;
            }
        }

        /// <summary>
        /// Skip items from iter.
        /// </summary>
        /// <param name="iter">Target iterate</param>
        /// <param name="count">Number of count.</param>
        /// <returns>Skipped sequence.</returns>
        private static IEnumerable<object> SkipIterate(Iterate iter, int count)
        {
            if (iter == null)
            {
                throw new ArgumentNullException(nameof(iter));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var fi = typeof(Iterate).GetField("_next", BindingFlags.Instance | BindingFlags.NonPublic);

            Debug.Assert(fi != null);

            long i = 0;

            while (i < count)
            {
                var n = (Iterate)iter.next();

                // clear _next cache in previous
                fi.SetValue(iter, null);

                iter = n;

                ++i;
            }

            return iter;
        }
    }
}
