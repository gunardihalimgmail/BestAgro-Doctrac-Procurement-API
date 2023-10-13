using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Procurement.Domain.Aggregate.Penutupan
{
    public class Ps_OP
    {
        [Key]
        public int ID_Ps_OP { get; set; }
        public int ID_Ms_UnitUsaha { get; set; }
        public int ID_Ms_Bagian { get; set; }
        public int ID_Ps_SPP { get; set; }
        public int ID_Bagian_Franco { get; set; }
        public int ID_Ms_Supplier { get; set; }
        public int ID_St_Franco { get; set; }
        public int ID_Ms_MataUang { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tanggal { get; set; }
        public string Alamat { get; set; }
        public string Syarat { get; set; }
        public string DeliveryTime { get; set; }
        public string TipeOP { get; set; }
        public int? JatuhTempo { get; set; }
        public string TipePembayaran { get; set; }
        public string Referensi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PPN { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PPh { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Diskon { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalNetto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalHarga { get; set; }

        public string Keterangan { get; set; }

        public string Status { get; set; }
        public string KeteranganStatus { get; set; }
        public int? JumlahPrint { get; set; }
        public string FlagInternal { get; set; }
        //public Byte[] RowVersion { get; set; }
        public string ModifyStatus { get; set; }
        public int? ID_Ms_Penutupan { get; set; }
        public string AlasanPenutupan { get; set; }
        public DateTime? TanggalPenutupan { get; set; }
        public string PerihalPenutupan { get; set; }
        public string IsApproved { get; set; }
        public int? IsApprovedBy { get; set; }
        public DateTime? IsApprovedTime { get; set; }

    }
}
