using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADGraphTest
{
    class GraphHelper
    {
        public static ActiveDirectoryClient CreateGraphClient(string accessToken, string tenantId)
        {
            string graphResourceId = "https://graph.windows.net";

            Uri servicePointUri = new Uri(graphResourceId);
            Uri serviceRoot = new Uri(servicePointUri, tenantId);

            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot, async () => await Task.FromResult(accessToken));

            return activeDirectoryClient;
        }

        public static ActiveDirectoryClient CreateGraphClient()
        {
            string accessToken = "";
            string tenantId = ""; 
            string graphResourceId = "https://graph.windows.net";

            Uri servicePointUri = new Uri(graphResourceId);
            Uri serviceRoot = new Uri(servicePointUri, tenantId);

            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot, async () => await Task.FromResult(accessToken));

            return activeDirectoryClient;
        }


    }
}
