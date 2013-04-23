using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;

namespace HomeTrax
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            /*  NOTE: you MUST replace of the xxxxxxxxxxxxxxx's with a valid appId and appSecret for your application
                in order to be able to connect!  Also, passing the extra data is only necessary if you want to
                show the images for the OpenID provider.
            */

            // Facebook 
            OAuthWebSecurity.RegisterFacebookClient(
                appId: "xxxxxxxxxxxxxxx",
                appSecret: "xxxxxxxxxxxxxxx");

            // Twitter
            OAuthWebSecurity.RegisterTwitterClient(
              consumerKey: "xxxxxxxxxxxxxxx",
              consumerSecret: "xxxxxxxxxxxxxxx");

            // Google
            OAuthWebSecurity.RegisterGoogleClient();

            // Yahoo
            OAuthWebSecurity.RegisterYahooClient();

            // Microsoft Windows Live Id
            OAuthWebSecurity.RegisterMicrosoftClient(
              clientId: "xxxxxxxxxxxxxxx",
              clientSecret: "xxxxxxxxxxxxxxx");
        }
    }
}
