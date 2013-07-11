using Owin;

namespace WhingePool
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseApplicationSignInCookie();

            // Enable the application to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie();

            app.UseTwitterAuthentication(
               consumerKey: "JsYU5yR1tZMrnKNKPzIvQg",
               consumerSecret: "TQ9UX1B7IsgS9AUfgeMJKrC9ZwrKdZwSQDKiaXb0");

        }
    }
}