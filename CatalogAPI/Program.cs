using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI
{
    class Program
    {
        static int Main(string[] args)
        {
            CatalogManager cm = new CatalogManager();

            if (args.Length == 0)
                return Usage();

            string arg0 = args[0];
            string filePath = args[1];
            char option = arg0[1];
            switch (option)
            {
                case 'w':
                    cm.CreateCatalogFile(filePath);
                    break;
                case 'r':
                    List<string> checksums = cm.ReadCatalogFile(filePath);
                    foreach (var cs in checksums)
                        Console.WriteLine(cs);
                    break;
            }
            return 0;
        }

        static int Usage()
        {
            Console.WriteLine("Usage: CatalogAPI [w|r] FilePath\n");
            Console.WriteLine("       -w Create catalog file from catalog definition file");
            Console.WriteLine("       -r Read catalog file to list the catalog entries\n");
            Console.WriteLine(@"Example: CatalogAPI -w ./test.cdf");
            Console.WriteLine(@"Example: CatalogAPI -r ./test.cat");
            return 0;
        }

    }
}
