using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using EmpleoDotNet.AppServices;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.MicrosoftAccount;
using Ninject;
using Owin;
using Tweetinvi;

namespace EmpleoDotNet
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var settings = new StandardKernel().Get<ISettingsProvider>();

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            var msAuthOptions = new MicrosoftAccountAuthenticationOptions();
            msAuthOptions.Scope.Add("wl.basic");
            msAuthOptions.Scope.Add("wl.emails");
            msAuthOptions.ClientId = settings.Get("msClientId");
            msAuthOptions.ClientSecret = settings.Get("msClientSecret");
            app.UseMicrosoftAccountAuthentication(msAuthOptions);

            var fbAuthOptions = new FacebookAuthenticationOptions
            {
                AppId = settings.Get("fbAppId"),
                AppSecret = settings.Get("fbAppSecret")
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
            app.UseGoogleAuthentication(
                clientId: settings.Get("googleClientId"),
                clientSecret: settings.Get("googleClientSecret")
            );
        }
    }
}