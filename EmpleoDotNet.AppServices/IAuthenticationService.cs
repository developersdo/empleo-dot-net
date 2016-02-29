using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EmpleoDotNet.AppServices
{
    public interface IAuthenticationService
    {
        string GenerateUserName();
        UserProfile GetUserProfile(string userId);
        IdentityUser CreateUserWithSocialProvider(string socialProvider, string providerKey, string accessToken);

    }
}
