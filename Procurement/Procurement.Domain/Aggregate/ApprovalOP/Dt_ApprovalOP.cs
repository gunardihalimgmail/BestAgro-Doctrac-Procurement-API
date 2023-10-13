using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Procurement.Domain.Aggregate.ApprovalOP
{
    public class Dt_ApprovalOP
    {
        [Key]
        public int ID_Dt_ApprovalOP { get; set; }
        public int? ID_Ms_Bagian_SPP { get; set; }
        public int? ID_Ps_OP { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Total { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PPN { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GrandTotal { get; set; }

        public int? IDLoginNegosiator { get; set; }
        public DateTime? TanggalApprovalNegosiator { get; set; }
        public int? IDLoginFactory { get; set; }
        public DateTime? TanggalApprovalFactory { get; set; }
        public int? IDLoginManager { get; set; }
        public DateTime? TanggalApprovalManager { get; set; }
        public int? IDLoginDirektur { get; set; }
        public DateTime? TanggalApprovalDirektur { get; set; }
    }
}
