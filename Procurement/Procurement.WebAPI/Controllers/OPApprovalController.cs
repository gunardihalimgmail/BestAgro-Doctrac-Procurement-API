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
using Procurement.Domain.DTO.OPApproval;
using Procurement.Domain.DTO.OPApproval.Request;
using Procurement.WebAPI.Application.Commands.ApprovalOP;
using Procurement.WebAPI.Application.Queries;

namespace Procurement.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OPApprovalController : ControllerBase
    {
        private readonly ILogger<OPApprovalController> _logger;
        private readonly IOPApprovalQueries _opApprovalQueries;
        private readonly ICommandHandler<UpdateApprovalOPCommand> _updateApprovalOPCommand;


        public OPApprovalController(ILogger<OPApprovalController> logger, IOPApprovalQueries opApprovalQueries, ICommandHandler<UpdateApprovalOPCommand> updateApprovalOPCommand)
        {
            _logger = logger;
            _opApprovalQueries = opApprovalQueries;
            _updateApprovalOPCommand = updateApprovalOPCommand;
        }


        [HttpGet]
        [Route("getlistop/{id_ms_login}")]
        [Authorize]
        public async Task<IActionResult> GetListOP(int id_ms_login)
        {
            try
            {
                #region start stopwatch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                #endregion

                var data = await _opApprovalQueries.GetListOP(id_ms_login);

                #region stop stopwatch
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine("RunTime Get List OP: " + ts); //+ " id_ms_login: " + id_ms_login + " Pukul: " + DateTime.Now
                #endregion

                return Ok(new ApiOkResponse(data));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get List OP");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpPost]
        [Route("getopdetailcompare")]
        [Authorize]
        public IActionResult GetDetailOPdanComparePenawaran([FromBody] OpApprovalDetailRequest request)
        {
            try
            {

                var result = new OpDetailCompare();

                var dataDetail = _opApprovalQueries.GetListDetail(request);
                var dataCompare = _opApprovalQueries.GetListCompare(request.id_ps_op);
                var dataPerubahanSpec = _opApprovalQueries.GetListPerubahanSpec(request.id_ps_op);
                //var dataCompareSpesifikasi = _opApprovalQueries.GetListCompare(request.id_ps_op);

                result.opapprovaldetail = dataDetail;
                result.opcompareharga = dataCompare;
                result.ophistoryspec = dataPerubahanSpec;
                
                //result.opcomparehargaspesifikasi = dataCompareSpesifikasi;


                OpDetailCompare[] castToArray = new OpDetailCompare[] { result };

                return Ok(new ApiOkResponse(result));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Get List OP Detail and Compare");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }


        [HttpPost]
        [Route("approveop")]
        [Authorize]
        public async Task<IActionResult> TerimaOP([FromBody] UpdateApprovalOPCommand request)
        {
            try
            {

                await _updateApprovalOPCommand.Handle(request, CancellationToken.None);

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
