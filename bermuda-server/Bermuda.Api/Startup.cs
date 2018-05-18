using Bermuda.Api.OAuth;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Bermuda.Api.Startup))]

namespace Bermuda.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888

            //HttpConfiguration config = new HttpConfiguration();

            // Cors config
            app.UseCors(CorsOptions.AllowAll);

            // OAuth config
            // must before router register
            ConfigureAuth(app);

            // Register routers
            //WebApiConfig.Register(config);

            // `UseWebApi` must be enable while `Microsoft.AspNet.WebApi.Owin` was installed
            //app.UseWebApi(config);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            // init custom OAuth authorization server provider
            var oAuthProvider = new BmdOAuthAuthorizationServerProvider();

            // init custom refresh token provider
            // var refreshTokenProvider = new BaseRefreshTokenProvider();

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
#if DEBUG
                AllowInsecureHttp = true, // for dev mode
#endif

                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60), // 1 hours
                Provider = oAuthProvider,
                // RefreshTokenProvider = refreshTokenProvider
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
