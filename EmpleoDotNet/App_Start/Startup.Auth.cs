using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Owin;
using Tweetinvi;

namespace EmpleoDotNet
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");


            var fbAuthOptions = new FacebookAuthenticationOptions
            {
                AppId = ConfigurationManager.AppSettings["fbAppId"],
                AppSecret = ConfigurationManager.AppSettings["fbAppSecret"]
            };
            
            fbAuthOptions.Scope.Add("email");
            fbAuthOptions.Scope.Add("public_profile");
            fbAuthOptions.Scope.Add("user_friends");
            fbAuthOptions.Provider = new FacebookAuthenticationProvider
            {
                OnAuthenticated = context =>
                {
                    context.Identity.AddClaim(new Claim("FacebookAccessToken",context.AccessToken));
                    return Task.FromResult(true);
                }
            };
                
            app.UseFacebookAuthentication(fbAuthOptions);

            //app.UseGoogleAuthentication();
        }
    }
}