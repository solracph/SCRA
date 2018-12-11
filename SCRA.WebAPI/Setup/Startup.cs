using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Http;
using System.Web.Http.Cors;
using SCRA.Common.Utilities;

namespace SCRA.WebApi.Setup
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = GlobalConfiguration.Configuration;

            var cors = new EnableCorsAttribute(Settings.Origins, Settings.Headers, Settings.Methods);
            configuration.EnableCors(cors);

            ConfigureAuth(app);

            WebApiConfig.Setup(configuration);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = TimeSpan.FromMinutes(Settings.SessionExpiration),
                SlidingExpiration = true,
                CookieName = "SCRA.WebAPI",
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = context =>
                    {
                        DateTimeOffset now = DateTimeOffset.UtcNow;

                        if (context.Properties.ExpiresUtc != null)
                            context.OwinContext.Request.Set("time.Remaining", context.Properties.ExpiresUtc.Value.Subtract(now).TotalSeconds);

                        return Task.FromResult<object>(null);
                    }
                }
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}