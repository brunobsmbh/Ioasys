using Microsoft.Owin.Security.OAuth;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Owin;
using Microsoft.Owin;
using Empresas.Data.Service;

namespace App_Empresaas.Provider
{
    public class TokenDeAcesso : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {         
            context.Validated();
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.AdditionalResponseParameters.Add("Client", "Bruno Mendes");
            return base.TokenEndpoint(context);
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            
            if (UsuarioService.Login(context.UserName, context.Password))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("acesso inválido", "As credenciais do usuário não conferem....");
                return;
            }
        }
    }
}