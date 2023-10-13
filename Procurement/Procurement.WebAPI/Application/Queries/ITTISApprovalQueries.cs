using Procurement.Domain.Aggregate.ApprovalTTIS;
using Procurement.Domain.DTO.TTISApproval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Queries
{
    public interface ITTISApprovalQueries
    {
        Task<List<TTISApproval>> GetOutstandingTTIS(int id_ms_login);
        Task<List<TTISDetail>> GetDetailTTIS(int id_ps_ttis);
        Task<List<LPBHistory>> GetHistoryLPB(int id_ps_ttis);
        Task<List<OPHistory>> GetHistoryOP(int id_ps_ttis);
        Task<Ps_TTIS> GetDataPsTTIS(int id_ps_ttis);
    }
}
