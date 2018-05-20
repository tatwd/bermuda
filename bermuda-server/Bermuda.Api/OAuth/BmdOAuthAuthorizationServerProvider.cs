using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Bermuda.Bll.Service;
using System.Security.Claims;
using Bermuda.Model;
using Bermuda.Common;
using Newtonsoft.Json;
using Bermuda.Api.Models;

namespace Bermuda.Api.OAuth
{
    public class BmdOAuthAuthorizationServerProvider
        : OAuthAuthorizationServerProvider
    {
        BmdUser authUser = new BmdUser();

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
                authUser = user;

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

        public override async Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            await Task.Run(() =>
            {
                var authUserVm = BaseUtil.ParseTo<UserViewModel>(authUser);
                var authUserStr = JsonConvert.SerializeObject(authUserVm);

                context.AdditionalResponseParameters.Add("login_at", BaseUtil.GetCurrentTimeStamp());
                context.AdditionalResponseParameters.Add("user", authUserStr);
            });
        }
    }
}
