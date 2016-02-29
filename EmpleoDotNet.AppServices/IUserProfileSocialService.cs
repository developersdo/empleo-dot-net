using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.AppServices
{
    public interface IUserProfileSocialService
    {
        UserProfile GetFromSocialProvider(string socialProvider, string accessToken);
    }
}
