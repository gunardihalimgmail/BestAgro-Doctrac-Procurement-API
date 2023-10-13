using Procurement.Domain.Aggregate.ApprovalOP;
using Procurement.Domain.DTO.OPApproval;
using Procurement.Domain.DTO.OPApproval.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Queries
{
    public interface IOPApprovalQueries
    {
        Task<List<OpApprovalDok>> GetListOP(int id_ms_login);
        List<OpApprovalDetail> GetListDetail(OpApprovalDetailRequest request);
        List<OpCompareHarga> GetListCompare(int id_ps_op);
        List<OpHistorySpec> GetListPerubahanSpec(int id_ps_op);
        List<OpCompareHarga> GetListCompareSpesifikasi(int id_ps_op);
        Task<UserRoleOp> GetJenisUserApproval(int id_ms_login);
        Task<Dt_ApprovalOP> GetDataApprovalOP(int id_ps_op);

    }
}
