using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BestAgroCore.Common.Api;
using BestAgroCore.Common.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Procurement.Domain.DTO.Penutupan.Request;
using Procurement.WebAPI.Application.Commands.Penutupan;
using Procurement.WebAPI.Application.Queries;

namespace Procurement.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PenutupanController : ControllerBase
    {
        private readonly ILogger<PenutupanController> _logger;
        private readonly IPenutupanQueries _opApprovalQueries;
        private readonly ICommandHandler<UpdatePenutupanCommand> _updatePenutupanCommand;

        public PenutupanController(ILogger<PenutupanController> logger, IPenutupanQueries opApprovalQueries, ICommandHandler<UpdatePenutupanCommand> updatePenutupanCommand)
        {
            _logger = logger;
            _opApprovalQueries = opApprovalQueries;
            _updatePenutupanCommand = updatePenutupanCommand;
        }

        [HttpGet]
        [Route("getlistpenutupan/{id_ms_login}")]
        [Authorize]
        public async Task<IActionResult> GetListPenutupan(int id_ms_login)
        {
            try
            {
                var data = await _opApprovalQueries.GetListPenutupan(id_ms_login);

                return Ok(new ApiOkResponse(data));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get List Penutupan");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpPost]
        [Route("getpenutupandetail")]
        [Authorize]
        public async Task<IActionResult> GetDetailPenutupan([FromBody] PenutupanDetailRequest request)
        {
            try
            {
                var data = await _opApprovalQueries.GetDetailPenutupan(request);

                return Ok(new ApiOkResponse(data));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get List Detail Penutupan");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpPost]
        [Route("approvepenutupan")]
        [Authorize]
        public async Task<IActionResult> TerimaPenutupan([FromBody] UpdatePenutupanCommand request)
        {
            try
            {

                await _updatePenutupanCommand.Handle(request, CancellationToken.None);

                return Ok(new ApiOkResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Update Approval OP");
                return Ok(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

    }
}
