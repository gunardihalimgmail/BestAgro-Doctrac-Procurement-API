using Procurement.Domain.DTO.ListOP;
using Procurement.Domain.DTO.ListOP.Request;
using Procurement.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Queries
{
    public interface IListOPQueries
    {
        Task<List<ListOP>> GetListDokumenOp(ListOPRequest request);
        Task<UserDetail> GetUserInfo(int idLogin);
        Task<List<DocFlowStatusOP>> GetDocFlowStatusOP(DocFlowStatusOPRequest request);
    }
}
