using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForToArray
{
    class Package {
        public string Company { get; set; }
        public double Weight { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Package> packages =
                   new List<Package> 
                        { new Package { Company = "Coho Vineyard", Weight = 25.2 },
                          new Package { Company = "Lucerne Publishing", Weight = 18.7 },
                          new Package { Company = "Wingtip Toys", Weight = 6.0 },
                          new Package { Company = "Adventure Works", Weight = 33.8 } };

            string[] companies = packages.Select(pkg => pkg.Company).ToArray();

            foreach (string company in companies)
            {
                Console.WriteLine(company);
            }
            Tree<int> tree1 = new Tree<int>(10);
            tree1.insert(1);
            tree1.insert(2);
            tree1.insert(4);
            tree1.insert(5);
            tree1.insert(12);
            tree1.insert(12);
            tree1.insert(32);
            tree1.insert(23);
            tree1.insert(4);
            tree1.insert(8);
            tree1.walkTree();
            tree1.delete(10);
            tree1.walkTree();
        }
    }
}
