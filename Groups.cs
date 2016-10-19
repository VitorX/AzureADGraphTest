using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADGraphTest
{
    class Groups
    {
        public void AddMember()
        {
            var client = GraphHelper.CreateGraphClient();

            var group = client.Groups.ExecuteAsync().Result.CurrentPage.First(a => a.DisplayName == "GroupForLocalWeb") as Microsoft.Azure.ActiveDirectory.GraphClient.Group;
            Console.Write(group.DisplayName);

            var user = client.Users.ExecuteAsync().Result.CurrentPage.First(u => u.DisplayName == "user2") as Microsoft.Azure.ActiveDirectory.GraphClient.DirectoryObject;

            group.Members.Add(user);
            group.UpdateAsync();

            
        }
    }
}
