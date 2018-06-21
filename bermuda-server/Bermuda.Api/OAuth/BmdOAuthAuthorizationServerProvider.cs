using Bermuda.Bll.Service;
using Bermuda.Common;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bermuda.Api.OAuth
{
    public class BmdOAuthAuthorizationServerProvider
        : OAuthAuthorizationServerProvider
    {
        private string _UserJson = String.Empty;

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

                _UserJson = AuthUtil.GetUserJsonString(user);

                identity.AddClaim(new Claim(ClaimTypes.Role, "user")); // role
                identity.AddClaim(new Claim(ClaimTypes.Name, _UserJson));

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "The username or password is incorrect.");
            }
        }

        public override async Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            await Task.Run(() =>
            {
                context.AdditionalResponseParameters.Add("login_at", BaseUtil.GetCurrentTimeStamp());
                context.AdditionalResponseParameters.Add("auth_token_url", context.Request.Uri.ToString());
                context.AdditionalResponseParameters.Add("current_user", _UserJson);
            });
        }
    }
}
