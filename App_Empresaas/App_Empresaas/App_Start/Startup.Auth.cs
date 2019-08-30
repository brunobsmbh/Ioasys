using App_Empresaas.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace App_Empresaas
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // configuracao WebApi
            var config = new HttpConfiguration();
            // configurando rotas
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional }
             );
            // ativando cors
            app.UseCors(CorsOptions.AllowAll);

            // ativando a geração do token
            AtivarGeracaoTokenAcesso(app);

            // ativando configuração WebApi
            app.UseWebApi(config);
        }


        private void AtivarGeracaoTokenAcesso(IAppBuilder app)
        {
            var configuracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/1.0/users/auth/sign_in"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new TokenDeAcesso()

            };
            app.UseOAuthAuthorizationServer(configuracaoToken);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


        }
    }
}