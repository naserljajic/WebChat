using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebChat.Models;

namespace WebChat.Factory
{
    public class CustomClaimsFactory : UserClaimsPrincipalFactory<Korisnik>
    {
        public CustomClaimsFactory(UserManager<Korisnik> userManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Korisnik user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Ime", user.Ime));
            identity.AddClaim(new Claim("Prezime", user.Prezime));
            return identity;
        }
    }
}
