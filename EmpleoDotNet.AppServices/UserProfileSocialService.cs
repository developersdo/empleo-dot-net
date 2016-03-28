﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;
using Microsoft.AspNet.Identity;

namespace EmpleoDotNet.AppServices
{
    public class UserProfileSocialService : IUserProfileSocialService
    {
        public UserProfile GetFromSocialProvider(string socialProvider, ClaimsIdentity identity)
        {
            switch (socialProvider)
            {
                case "Facebook":
                    return GetFromFacebook(identity);
                case "Google":
                    return GetFromGoogle(identity);
                case "Microsoft":
                    return GetFromMicrosoft(identity);
                default:
                    return new UserProfile();
            }
        }

        private UserProfile GetFromMicrosoft(ClaimsIdentity identity)
        {
            var email = identity.FindFirst(x => x.Type.Contains("emailaddress")).Value;
            var name = identity.Name;
            return new UserProfile
            {
                Email = email,
                Name = name
            };
        }

        private UserProfile GetFromGoogle(ClaimsIdentity identity)
        {
            var email = identity.FindFirst(x => x.Type.Contains("emailaddress")).Value;
            var name = identity.Name;
            return new UserProfile
            {
                Email = email,
                Name = name
            };
        }

        private UserProfile GetFromFacebook(ClaimsIdentity identity)
        {
            string accessToken = identity.FindFirstValue("FacebookAccessToken");
            var fbClient = new Facebook.FacebookClient(accessToken);
            dynamic fbInfo = fbClient.Get("/me?fields=id,name,email,first_name,last_name");
            return new UserProfile
            {
                Email = fbInfo.email,
                Name = fbInfo.name
            };
        }
    }
}
