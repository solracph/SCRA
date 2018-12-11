using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SCRA.Domain.Clinical;
using SCRA.Framework.Common.Models;

namespace SCRA.Framework.Clinical
{
    public interface IClinicalService
    {
        Task<Result> GetApplications();
        Task<Result> GetContracts();
        Task<Result> GetMeasures();
        Task<Result> GetPbpList();
        Task<Result> GetRules();
        Task<Result> GetSegments();
        Task<Result> GetTinList();
        Task<Result> GetUsers();
        Task<Result> CreateNewRule(Rule rule);
        Task<Result> DeleteRule(Rule RuleId);
        Task<Result> UpdateRule(Rule RuleId);
        Task<Result> UpdateUserRules(IList<User> User);

    }
}
