using System;
using System.Collections.Generic;
using System.Security.Claims;
using SCRA.Data.Security.Models;
using SCRA.Data.Security.Services;
using SCRA.Data.Security.Setup;
using SCRA.Domain.Security;
using SCRA.Framework.Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using SCRA.Framework.Common.Errors;

namespace SCRA.Framework.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly UserManager<IdentityUser, Guid> _userManager;

        private readonly IAuthenticationManager _authenticationManager;

        public SecurityService(IAuthenticationManager authenticationManager)
        {
            _userManager = new UserManager<IdentityUser, Guid>(new UserStore(new SecurityDbService()));
            _authenticationManager = authenticationManager;
        }

        public async Task<Result> SignIn(Login credentials, IOwinContext context)
        {
            IdentityUser user = await _userManager.FindAsync(credentials.UserName, credentials.Password);

            if (user != null)
            {
                _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = credentials.RememberMe }, identity);

                return Result.New(new { userName = credentials.UserName });
            }

            return Result.New().SetError("Login Failed", new Exception("Invalid Username or Password"));
        }


        public async Task<Result> Register(Register registrant)
        {
            IdentityUser identityUser = new IdentityUser { UserName = registrant.UserName, Email = registrant.Email };
            IdentityResult identityResult = await _userManager.CreateAsync(identityUser, registrant.Password);
            if (identityResult.Succeeded)
                return Result.New(identityUser);

            IList<Error> errors = new List<Error>();

            foreach (string errorMessage in identityResult.Errors)
                errors.Add(new Error(errorMessage, new Exception(), errorMessage, null));

            return Result.New(identityUser, errors);
        }

        public async Task<Result> GetUserContext(string userId, IOwinContext context)
        {
            Guid id;

            bool userValid = Guid.TryParse(userId, out id);

            if (userValid)
            {
                int expTime =  Convert.ToInt32(context.Environment["time.Remaining"]);
                IdentityUser user = await _userManager.FindByIdAsync(id);
                IList<string> roles = _userManager.GetRoles(user.Id);

                return Result.New(new UserContext(user.UserName, user.Email, roles, true, expTime));
            }

            return Result.New().SetError("User not autheticated", new Exception("The User is not authenticated"));
        }

        public async Task<Result> SignOut()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return Result.New("Log-off");
        }
    }
}
