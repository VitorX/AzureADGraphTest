using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADGraphTest
{
    class Program
    {
        static void Main(string[] args)
        {

            new Tenants().PrintInfo();
            Console.Read();
        }

        
    }
}
