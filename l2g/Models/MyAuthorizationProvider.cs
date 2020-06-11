using l2g.BL;
using l2g.BL.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace l2g.Models
{
    public class MyAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        //private IAuthBL _authBL;
        //public MyAuthorizationProvider(IAuthBL authBL)
        //{
        //    _authBL = authBL;
        //}
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //var user = _authBL.ValidateUser(context.UserName, context.Password);
            AuthBL authBL = new AuthBL();
            var user = authBL.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Username or Password is invalid!");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            context.Validated(identity);
        }
    }
}