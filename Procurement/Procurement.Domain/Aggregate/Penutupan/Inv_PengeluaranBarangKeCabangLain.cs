using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.Aggregate.Penutupan
{
    public class Inv_PengeluaranBarangKeCabangLain
    {
        [Key]
        public int ID_Inv_PengeluaranBarangKeCabangLain { get; set; }
        public int? ID_Ms_UnitUsaha { get; set; }
        public int? ID_Ms_Bagian { get; set; }
        public int? ID_Ms_Bagian_Tujuan { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tanggal { get; set; }
        public string Keterangan { get; set; }
        //public Byte[] RowVersion { get; set; }
        public string ModifyStatus { get; set; }
        public int? ID_Ms_Penutupan { get; set; }
        public string PerihalPenutupan { get; set; }
        public string AlasanPenutupan { get; set; }
        public DateTime? TanggalPenutupan { get; set; }
        public DateTime? TanggalPengeluaran { get; set; }
    }
}
