using SCRA.Domain.Security;
using SCRA.Framework.Common.Models;
using Microsoft.Owin;
using System.Threading.Tasks;

namespace SCRA.Framework.Security
{
    public interface ISecurityService
    {
        Task<Result> SignIn(Login credentials, IOwinContext context);
        Task<Result> Register(Register registrant);
        //Task<Result> GetUserContext(string userId, IOwinContext context);
        Task<Result> SignOut();
        //string GetCenterFromContext();
    }
}
