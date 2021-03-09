
using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace KursiIm.Business
{
    public class IdentityHelper
    {
        public static HttpContext SetIdentity(HttpContext context, User user)
        {
            var claims = new[] {
                                    new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                                    new Claim(ClaimTypes.Name, user.Account),
                               };
            var identity = new ClaimsIdentity(claims, AuthenticationSchemes.Basic.ToString());
            var userPrincipal = new GenericPrincipal(identity, new[] { "admin" });
            context.User = userPrincipal;

            return context;
        }
    }
}
