using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Bermuda.Bll.Service;
using System.Security.Claims;

namespace Bermuda.Api.OAuth
{
    public class BmdOAuthAuthorizationServerProvider
        : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() =>
            {
                context.Validated();
            });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var iservice = ServiceFactory.Get<IBmdUserService>();
            var user = await iservice.SignInWithUsernameAndPasswordAsync(context.UserName, context.Password);

            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Role, "user")); // role
                identity.AddClaim(new Claim("UserId", user.Id.ToString()));
                //identity.AddClaim(new Claim("Username", user.Name));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "The username or password is incorrect.");
            }
        }
    }
}
