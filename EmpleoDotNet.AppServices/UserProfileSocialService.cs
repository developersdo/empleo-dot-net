using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.AppServices
{
    public class UserProfileSocialService : IUserProfileSocialService
    {
        public UserProfile GetFromSocialProvider(string socialProvider, string accessToken)
        {
            var userProfile = new UserProfile();

            if (socialProvider == "Facebook")
            {
                var fbClient = new Facebook.FacebookClient(accessToken);
                dynamic fbInfo = fbClient.Get("/me?fields=id,name,email,first_name,last_name");

                userProfile.Email = fbInfo.email;
                userProfile.Name = fbInfo.name;
            }

            return userProfile;
        }
    }
}
