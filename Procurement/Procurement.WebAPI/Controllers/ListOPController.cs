using BestAgroCore.Common.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Procurement.Domain.DTO.ListOP;
using Procurement.Domain.DTO.ListOP.Request;
using Procurement.Domain.DTO.User;
using Procurement.WebAPI.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Procurement.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ListOPController : ControllerBase
    {
        private readonly ILogger<ListOPController> _logger;
        private readonly IListOPQueries _listOPQueries;

        public ListOPController(ILogger<ListOPController> logger, IListOPQueries listOPQueries)
        {
            _logger = logger;
            _listOPQueries = listOPQueries;
        }

        [HttpPost]
        [Route("getlistdokumenop")]
        public async Task<IActionResult> GetListDokumenOp([FromBody] ListOPRequest request)
        {
            try
            {

                List<ListOP> listOp = new List<ListOP>();

                DateTime start = new DateTime(Convert.ToInt32(request.RequestDateFrom.Substring(0, 4)),
                                        Convert.ToInt32(request.RequestDateFrom.Substring(4, 2)),
                                        Convert.ToInt32(request.RequestDateFrom.Substring(6, 2)));

                DateTime end = new DateTime(Convert.ToInt32(request.RequestDateTo.Substring(0, 4)),
                                        Convert.ToInt32(request.RequestDateTo.Substring(4, 2)),
                                        Convert.ToInt32(request.RequestDateTo.Substring(6, 2)));

                UserDetail qGet = _listOPQueries.GetUserInfo(request.IdLogin).Result;

                if (qGet.Bagian == null && qGet.Divisi == null)
                {
                    return BadRequest(new ApiBadRequestResponse(500, "No User Found"));
                }

                ListOPRequest opRequestTemp = new ListOPRequest();
                opRequestTemp = request;
                opRequestTemp.RequestDateFrom = start.ToString();
                opRequestTemp.RequestDateTo = end.ToString();

                var data = await _listOPQueries.GetListDokumenOp(opRequestTemp);

                return Ok(new ApiOkResponse(data));

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on View List Dokumen OP");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

        [HttpPost]
        [Route("getdokflowstatusOP")]
        public async Task<IActionResult> GetDocFlowStatusOP([FromBody] DocFlowStatusOPRequest request)
        {
            try
            {
                var data = await _listOPQueries.GetDocFlowStatusOP(request);
                return Ok(new ApiOkResponse(data));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on View List Dokumen Flow Status OP");
                return BadRequest(new ApiBadRequestResponse(500, "Something Wrong"));
            }
        }

    }
}
