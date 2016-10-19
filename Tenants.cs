using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADGraphTest
{
    class Tenants
    {

        public void PrintInfo()
        {
            var client = GraphHelper.CreateGraphClient();
            Console.WriteLine(client.TenantDetails.ExecuteAsync().Result.CurrentPage.First().CountryLetterCode);
        }
    }
}
