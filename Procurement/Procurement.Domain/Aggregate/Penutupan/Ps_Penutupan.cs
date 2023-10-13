using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.Aggregate.Penutupan
{
    public class Ps_Penutupan
    {
        [Key]
        public int ID_Ps_Penutupan { get; set; }
        public int? ID_Referensi { get; set; }
        public string JenisPenutupan { get; set; }
        public string PerihalPenutupan { get; set; }
        public string AlasanPenutupan { get; set; }
        public DateTime? TanggalPenutupan { get; set; }
        public int? ID_Ms_Login { get; set; }
        public int? ID_Negosiator { get; set; }
        public DateTime? TanggalApproved { get; set; }
        public DateTime? TanggalRejected { get; set; }
        public DateTime? TanggalApprovedDir { get; set; }
        public DateTime? TanggalRejectedDir { get; set; }
        public string ModifyStatus { get; set; }
        
    }
}
