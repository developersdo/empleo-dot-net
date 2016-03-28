using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;
using Microsoft.AspNet.Identity;

namespace EmpleoDotNet.AppServices
{
    public interface IUserProfileSocialService
    {
        UserProfile GetFromSocialProvider(string socialProvider, ClaimsIdentity idenitity);
    }
}
