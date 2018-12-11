using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCRA.Domain.Clinical;
using SCRA.Framework.Clinical;
using SCRA.Framework.Common.Models;

namespace SCRA.Core.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicalController : ControllerBase
    {

        private readonly ClinicalService _clinicalService;

        public ClinicalController(ClinicalService ClinicalService)
        {
            _clinicalService = ClinicalService;
        }

        // [Authorize]
        [HttpGet("get-applications")]
        public Task<Result> GetApplications()
        {
            return _clinicalService.GetApplications();
        }

        // [Authorize]
        [HttpGet("get-contracts")]
        public Task<Result> GetContracts( )
        {
            return _clinicalService.GetContracts();
        }

        // [Authorize]
        [HttpGet("get-measures")]
        public Task<Result> GetMeasures( )
        {
            return _clinicalService.GetMeasures();
        }

        // [Authorize]
        [HttpGet("get-pbp-list")]
        public Task<Result> GetPbpList( )
        {
            return _clinicalService.GetPbpList();
        }

        // [Authorize]
        [HttpGet("get-rules")]
        public Task<Result> GetRules( )
        {
            return _clinicalService.GetRules();
        }

        // [Authorize]
        [HttpGet("get-segments")]
        public Task<Result> GetSegments( )
        {
            return _clinicalService.GetSegments();
        }

        // [Authorize]
        [HttpGet("get-tin-list")]
        public Task<Result> GetTinList( )
        {
            return _clinicalService.GetTinList();
        }

        // [Authorize]
        [HttpGet("get-users")]
        public Task<Result> GetUsers( )
        {
            return _clinicalService.GetUsers();
        }

        // [Authorize]
        [HttpPost("create-new-rule")]
        public Task<Result> CreateNewRule(Rule Rule)
        {
            return _clinicalService.CreateNewRule(Rule);
        }

        // [Authorize]
        [HttpPost("delete-rule")]
        public Task<Result> DeleteRule(Rule Rule)
        {
            return _clinicalService.DeleteRule(Rule);
        }

        // [Authorize]
        [HttpPost("update-rule")]
        public Task<Result> UpdateRule(Rule Rule)
        {
            return _clinicalService.UpdateRule(Rule);
        }


        // [Authorize]
        [HttpPost("update-user-rules")]
        public Task<Result> UpdateUserRules([FromBody] List<User> users)
        {
            return _clinicalService.UpdateUserRules(users);
        }

    }
}
