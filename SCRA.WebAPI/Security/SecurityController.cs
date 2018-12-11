using System;
using System.Web;
using System.Web.Http;
using SCRA.Domain.Security;
using SCRA.Framework.Common.Models;
using SCRA.Framework.Security;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace SCRA.WebApi.Security
{
    public class SecurityController : ApiController
    {
        private readonly SecurityService _securityService;

        public SecurityController()
        {
            _securityService = new SecurityService(HttpContext.Current.GetOwinContext().Authentication);
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("sign-in")]
        public Task<Result> Login(Login credentials)
        {
            return _securityService.SignIn(credentials, HttpContext.Current.GetOwinContext());
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("get-user-context")]
        public Task<Result> GetUserContext()
        {
            return _securityService.GetUserContext(User.Identity.GetUserId<string>(), HttpContext.Current.GetOwinContext());
        }

        [HttpPost]
        [ActionName("sign-out")]
        [AllowAnonymous]
        public async Task<Result> Logout()
        {
            return await _securityService.SignOut();
        }

        [HttpPost]
        [ActionName("register")]
        [Authorize(Roles="Admin")]
        public async Task<Result> Register(Register register)
        {
            return await _securityService.Register(register);
        }
    }
}