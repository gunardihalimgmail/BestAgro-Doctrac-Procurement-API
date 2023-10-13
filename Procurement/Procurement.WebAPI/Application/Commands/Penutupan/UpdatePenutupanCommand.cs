using BestAgroCore.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Commands.Penutupan
{
    public class UpdatePenutupanCommand : ICommand
    {
        public int ID_Ms_Login { get; set; }
        public int ID { get; set; } // as ID_Ps_SPP || ID_Ps_OP || ID_Inv_PengeluaranBarangKeCabangLain
        public string Jenis { get; set; }
        public string FlagApproveOrReject { get; set; }
    }
}
