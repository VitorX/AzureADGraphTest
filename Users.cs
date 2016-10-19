using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADGraphTest
{
    public class Users
    {



        private async Task<User> GetUserByUserName(ActiveDirectoryClient adClient, string userName)
        {
            var user = await adClient.Users.Where(u => u.UserPrincipalName == userName).ExecuteSingleAsync();
            return (User)user;
        }

        public async Task<AADUser> GetUserByPrincipalName(string userName)
        {

            ActiveDirectoryClient client = GraphHelper.CreateGraphClient();

            var user = await GetUserByUserName(client, userName);

            return new AADUser()
            {
                displayName = user.DisplayName
            };
          
        }

        public void AddUser(string accessToken)
        {

            ActiveDirectoryClient client = GraphHelper.CreateGraphClient();

            User user = new User();
            user.AccountEnabled = true;
            user.DisplayName = "displayName";
            user.MailNickname = "displayName2";
            user.PasswordProfile = new PasswordProfile { ForceChangePasswordNextLogin=false, Password="asdf123("  };
            user.UserPrincipalName = "displayName2@adfei.onmicrosoft.com";
            client.Users.AddUserAsync(user);
        }

    }

    public class AADUser
    {
        public string displayName;

    }
}
