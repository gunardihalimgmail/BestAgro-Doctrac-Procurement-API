using Procurement.Domain.Aggregate.Penutupan;
using Procurement.Domain.DTO.Penutupan;
using Procurement.Domain.DTO.Penutupan.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Queries
{
    public interface IPenutupanQueries
    {
        Task<List<PenutupanProcurement>> GetListPenutupan(int id_ms_login);
        Task<List<PenutupanProcurementDetail>> GetDetailPenutupan(PenutupanDetailRequest request);
        Task<string> GetDivisiName(int id_ms_login);
        Task<Ps_Penutupan> GetDataPenutupan(int ID, string jenis);
        Task<Ps_Spp> GetDataSPP(int id_ps_spp);
        Task<Ps_OP> GetDataOP(int id_ps_op);
        Task<Inv_PengeluaranBarangKeCabangLain> GetDataPengeluaranBarangKeCabangLain(int id_inv_pengeluaranbarangkecabanglain);
    }
}
