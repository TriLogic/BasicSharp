using System;
using System.IO;
using System.Collections.Generic;

namespace BasicSharp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var WorkingDir = GetWorkingDir();

            foreach (string file in Directory.GetFiles(WorkingDir, "*.bas"))
            {
                Interpreter basic = new Interpreter(File.ReadAllText(file));
                basic.printHandler += Console.WriteLine;
                basic.inputHandler += Console.ReadLine; 
                try
                {
                    basic.Exec();
                }
                catch (Exception e)
                {
                    Console.WriteLine("BAD");
                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("OK");
            }
            Console.Read();
        }

        static string GetWorkingDir()
        {
            var exeDir = AppContext.BaseDirectory;

            var solutionDir = Path.GetFullPath(
                Path.Combine(exeDir, "..", "..", "..")
            );

            var testDir = Path.Combine(solutionDir, "Tests");
            return testDir;
        }
    }
}
