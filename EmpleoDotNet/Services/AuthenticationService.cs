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
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationService(IUserProfileRepository userProfileRepository, UserManager<IdentityUser> userManager )
        {
            _userProfileRepository = userProfileRepository;
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

            var userProfile = new UserProfile();

            //TODO: Move This to another method
            if (socialProvider == "Facebook")
            {
                var fbClient = new Facebook.FacebookClient(accessToken);
                dynamic fbInfo = fbClient.Get("/me?fields=id,name,email,first_name,last_name");

                userProfile.Email = fbInfo.email;
                userProfile.Name = fbInfo.name;
            }

            var user = new IdentityUser(GenerateUserName());
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



//////Automatically create emplea.do account

////var userProfile = new UserProfile();

//                //Create user profile based on social auth info
//                if (login.LoginProvider == "Facebook")
//                {
//                    var access_token = result.Identity.FindFirstValue("FacebookAccessToken");

//var fbClient = new Facebook.FacebookClient(access_token);
//dynamic fbInfo = fbClient.Get("/me?fields=id,name,email,first_name,last_name"); // specify the email field

//userProfile.Email = fbInfo.email;
//                    userProfile.Name = fbInfo.name;
//                }
                

//                user = new IdentityUser(userProfile.Email);
//var userCreationResult = await UserManager.CreateAsync(user);
//                if (userCreationResult.Succeeded)
//                {
//                    var userLoginResult = await UserManager.AddLoginAsync(user.Id, login);
//                    if (userLoginResult.Succeeded)
//                    {
//                        await SignInAsync(user, isPersistent: false);
//                    }
//                }
//                else
//                {
//                    AddErrors(userCreationResult);
//                    return RedirectToAction("Login");
//                }


//                userProfile.UserId = user.Id;
//                _userProfileRepository.Add(userProfile);
//                _userProfileRepository.SaveChanges();