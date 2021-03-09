using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KursiIm.Business;
using KursiIm.SharedModel.Logs;
using KursiIm.SharedModel.Users;
using KursiImSource.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KursiImSource.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet("userAuthorization")]
        [SwaggerOperation(Summary = "Log User Authorization", Description = "This endpoint is used to Log User Authorization when the user signout" +
           "</br> ResponseBody \"status\" can be Done=0")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult LogAuth([FromQuery] bool isFromPortal) => Ok(_logService.SetLogUserAuthorization((int)UserAuthorizationStatus.SignOut, isFromPortal));

        [HttpPost("userActivity")]
        [SwaggerOperation(Summary = "Log User Activity", Description = "This endpoint is used to set Log User Activity when the user take an action" +
            "</br> ResponseBody \"status\" can be Done=0")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult LogActivity(LogActivityModel _) => Ok(_logService.SetLogUserActivity(_));

        [HttpGet("userActivities/{idUser}")]
        [SwaggerOperation(Summary = "Log User Activity", Description = "This endpoint is used to get Log User Activity of a specific user using idUser" +
            "</br> ResponseBody \"status\" can be Done=0")]
        [ProducesResponseType(typeof(Response<LogWithIdEntryUser>), 200)]
        public IActionResult LogUserActivities(int idUser) => Ok(_logService.GetResponseLogActivities(idUser));

        [HttpGet("getTables")]
        [SwaggerOperation(Summary = "Table", Description = "This endpoint is used to get Table" +
            "</br> ResponseBody \"status\" can be Done=0")]
        [ProducesResponseType(typeof(Response<TableModel>), 200)]
        public IActionResult Tables() => Ok(_logService.GetTables());
    }
}