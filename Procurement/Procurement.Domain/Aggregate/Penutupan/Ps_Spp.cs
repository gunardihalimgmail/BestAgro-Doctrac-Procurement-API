using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.Aggregate.Penutupan
{
    public class Ps_Spp
    {
        [Key]
        public int ID_Ps_SPP { get; set; }
        public int? ID_Ms_UnitUsaha { get; set; }
        public int? ID_Ms_Bagian { get; set; }
        public int? ID_Ms_GolonganBarang { get; set; }
        public int? Pembuat { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tanggal { get; set; }
        public string Keterangan { get; set; }
        public string Status { get; set; }
        public string KeteranganStatus { get; set; }
        public string Internal { get; set; }
        public string FlagJenisBarang { get; set; }
        //public Byte[] RowVersion { get; set; }
        public string ModifyStatus { get; set; }
        public int? ID_Ms_ApprovalDivisi { get; set; }
        public DateTime? TanggalApprovalDivisi { get; set; }
        public string AlasanApprovalDivisi { get; set; }
        public int? ID_Ms_ApprovalPKS { get; set; }
        public DateTime? TanggalApprovalPKS { get; set; }
        public string AlasanApprovalPKS { get; set; }
        public int? ID_Ms_ApprovalBNC { get; set; }
        public DateTime? TanggalApprovalBNC { get; set; }
        public string AlasanApprovalBNC { get; set; }
        public int? ID_Ms_Negosiator { get; set; }
        public DateTime? TanggalNegosiator { get; set; }
        public string AlasanNegosiator { get; set; }
        public int? ID_Ms_Penutupan { get; set; }
        public string AlasanPenutupan { get; set; }
        public DateTime? TanggalPenutupan { get; set; }
        public string PerihalPenutupan { get; set; }
        public int IsUrgent { get; set; }

    }
}
