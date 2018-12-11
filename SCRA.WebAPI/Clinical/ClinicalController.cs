using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Collections.Generic;
using SCRA.Framework.Common.Models;
using SCRA.Framework.Clinical;
using SCRA.Domain.Clinical;

namespace SCRA.WebApi.Clinical
{
    public class ClinicalController : ApiController
    {
        private IClinicalService _clinicalService;

        public ClinicalController(IClinicalService clinicalService)
        {
            _clinicalService = clinicalService;
        }

        [HttpGet]
       // [Authorize]
        [ActionName("get-applications")]
        public Task<Result> GetApplications()
        {
            return _clinicalService.GetApplications();
        }

        [HttpGet]
        // [Authorize]
        [ActionName("get-contracts")]
        public Task<Result> GetContracts()
        {
            return _clinicalService.GetContracts();
        }

        [HttpGet]
        // [Authorize]
        [ActionName("get-measures")]
        public Task<Result> GetMeasures()
        {
            return _clinicalService.GetMeasures();
        }

        [HttpGet]
        // [Authorize]
        [ActionName("get-pbp-list")]
        public Task<Result> GetPbpList()
        {
            return _clinicalService.GetPbpList();
        }

        [HttpGet]
        // [Authorize]
        [ActionName("get-rules")]
        public Task<Result> GetRules()
        {
            return _clinicalService.GetRules();
        }

        [HttpGet]
        // [Authorize]
        [ActionName("get-segments")]
        public Task<Result> GetSegments()
        {
            return _clinicalService.GetSegments();
        }

        [HttpGet]
        // [Authorize]
        [ActionName("get-tin-list")]
        public Task<Result> GetTinList()
        {
            return _clinicalService.GetTinList();
        }

        [HttpGet]
        // [Authorize]
        [ActionName("get-users")]
        public Task<Result> GetUsers()
        {
            return _clinicalService.GetUsers();
        }

        [HttpPost]
        // [Authorize]
        [ActionName("create-new-rule")]
        public Task<Result> CreateNewRule(Rule Rule)
        {
            return _clinicalService.CreateNewRule(Rule);
        }

        [HttpPost]
        // [Authorize]
        [ActionName("delete-rule")]
        public Task<Result> DeleteRule(Rule Rule)
        {
            return _clinicalService.DeleteRule(Rule);
        }

        [HttpPost]
        // [Authorize]
        [ActionName("update-rule")]
        public Task<Result> UpdateRule(Rule Rule)
        {
            return _clinicalService.UpdateRule(Rule);
        }


        [HttpPost]
        // [Authorize]
        [ActionName("update-user-rules")]
        public Task<Result> UpdateUserRules(IList<User> users)
        {
            return _clinicalService.UpdateUserRules(users);
        }
    }
}