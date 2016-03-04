using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Repository.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EmpleoDotNet.Services
{
    

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserProfileSocialService _userProfileSocialService;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationService(
            IUserProfileRepository userProfileRepository, 
            IUserProfileSocialService userProfileSocialService,
            UserManager<IdentityUser> userManager )
        {
            _userProfileRepository = userProfileRepository;
            _userProfileSocialService = userProfileSocialService;
            _userManager = userManager;
        }

        public string GenerateUserName()
        {   
            return $"{Guid.NewGuid().ToString("N")}@emplea.do";
        }

        public UserProfile GetUserProfile(string userId)
        {
            throw new NotImplementedException();
        }

        public IdentityUser CreateUserWithSocialProvider(string socialProvider, string providerKey, string accessToken)
        {
            var userProfile = _userProfileSocialService.GetFromSocialProvider(socialProvider, accessToken);

            var user = new IdentityUser(GenerateUserName())
            {
                Email = userProfile.Email
            };
            var login = new UserLoginInfo(socialProvider, providerKey);

            var userCreationResult = _userManager.Create(user);
            if (userCreationResult.Succeeded)
            {
                var userLoginResult = _userManager.AddLogin(user.Id, login);
                if (!userLoginResult.Succeeded)
                {
                    foreach (var error in userLoginResult.Errors)
                    {
                        throw new Exception(error);
                    }
                }
            }
            else
            {
                foreach (var error in userCreationResult.Errors)
                {
                    throw new Exception(error);
                }
            }

            userProfile.UserId = user.Id;
            _userProfileRepository.Add(userProfile);
            _userProfileRepository.SaveChanges();

            return user;
        }
    }
}
