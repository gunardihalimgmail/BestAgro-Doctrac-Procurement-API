using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BestAgroCore.Common.Api;
using BestAgroCore.Common.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Procurement.Domain.DTO;
using Procurement.Domain.DTO.TTISApproval;
using Procurement.Domain.DTO.TTISApproval.Request;
using Procurement.WebAPI.Application.Commands.ApprovalTTIS;
using Procurement.WebAPI.Application.Queries;


namespace Procurement.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TTISApprovalController : ControllerBase
    {
        private readonly ILogger<TTISApprovalController> _logger;
        private readonly ITTISApprovalQueries _ttisApprovalQueries;
        private readonly ICommandHandler<UpdateApprovalTTISCommand> _updateApprovalTTISCommand;
        private readonly ICommandHandler<UpdateMultipleApprovalTTISCommand> _updateMultipleApprovalTTISCommand;

        public TTISApprovalController(ILogger<TTISApprovalController> logger,
            ITTISApprovalQueries ttisApprovalQueries,
            ICommandHandler<UpdateApprovalTTISCommand> updateApprovalTTISCommand,
            ICommandHandler<UpdateMultipleApprovalTTISCommand> updateMultipleApprovalTTISCommand)
        {
            _logger = logger;
            _ttisApprovalQueries = ttisApprovalQueries;
            _updateApprovalTTISCommand = updateApprovalTTISCommand;
            _updateMultipleApprovalTTISCommand = updateMultipleApprovalTTISCommand;
        }

        [HttpGet]
        [Route("getlistoutstandingttis/{id_ms_login}")]
        [Authorize]
        public async Task<IActionResult> GetListOutstandingTTIS(int id_ms_login)
        {
            try
            {
                #region start stopwatch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                #endregion

                var data = await _ttisApprovalQueries.GetOutstandingTTIS(id_ms_login);

                #region stop stopwatch
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine("RunTime Get Outstanding TTIS: " + ts);
                #endregion

                return Ok(new ApiOkResponse(data));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get  Outstanding TTIS");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpGet]
        [Route("getdetailttis/{id_ps_ttis}")]
        [Authorize]
        public async Task<IActionResult> GetDetailTTIS(int id_ps_ttis)
        {
            try
            {
                #region start stopwatch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                #endregion

                var data = await _ttisApprovalQueries.GetDetailTTIS(id_ps_ttis);

                #region stop stopwatch
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine("RunTime Get Detail TTIS: " + ts);
                #endregion

                return Ok(new ApiOkResponse(data));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get Detail TTIS");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpGet]
        [Route("gethistoryop/{id_ps_ttis}")]
        [Authorize]
        public async Task<IActionResult> GetHistoryOP(int id_ps_ttis)
        {
            try
            {
                #region start stopwatch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                #endregion

                var data = await _ttisApprovalQueries.GetHistoryOP(id_ps_ttis);

                #region stop stopwatch
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine("RunTime Get History OP: " + ts);
                #endregion

                return Ok(new ApiOkResponse(data));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get History OP");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpGet]
        [Route("gethistorylpb/{id_ps_ttis}")]
        [Authorize]
        public async Task<IActionResult> GetHistoryLPB(int id_ps_ttis)
        {
            try
            {
                #region start stopwatch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                #endregion

                var data = await _ttisApprovalQueries.GetHistoryLPB(id_ps_ttis);

                #region stop stopwatch
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine("RunTime Get History LPB: " + ts);
                #endregion

                return Ok(new ApiOkResponse(data));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get History LPB");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpPost]
        [Route("approvettis")]
        [Authorize]
        public async Task<IActionResult> ApproveTTIS([FromBody] UpdateApprovalTTISCommand request)
        {
            try
            {
                await _updateApprovalTTISCommand.Handle(request, CancellationToken.None);
                return Ok(new ApiOkResponse(200));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Update Approval OP");
                return Ok(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpPost]
        [Route("approvemultiplettis")]
        [Authorize]
        public async Task<IActionResult> MultipleApproveTTIS([FromBody] UpdateMultipleApprovalTTISCommand request)
        {
            try
            {
                string message = "";

                await _updateMultipleApprovalTTISCommand.Handle(request, CancellationToken.None);

                if (message == "")
                {
                    return Ok(new ApiOkResponse(200));
                }
                else
                {
                    return Ok(new ApiOkResponse(message));
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Terima SPD");
                return Ok(new ApiBadRequestResponse(500, "Something Wrong"));

            }
        }

    }
}
