using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procurement.Domain.DTO.OPApproval
{
    public class OpDetailCompare
    {
        public IEnumerable<OpApprovalDetail> opapprovaldetail { get; set; }
        public IEnumerable<OpCompareHarga> opcompareharga { get; set; }
        public IEnumerable<OpHistorySpec> ophistoryspec { get; set; }

        //public IEnumerable<OpCompareHarga> opcomparehargaspesifikasi { get; set; }
    }

    public class OpApprovalDetail
    {
        public Int64 ID { get; set; }
        public int ID_Ps_OP { get; set; }
        public string NomorOP { get; set; }
        public int ID_Ps_SPP { get; set; }
        public string NomorSPP { get; set; }
        public int ID_Ms_Barang { get; set; }
        public string NamaBarang { get; set; }
        public string Satuan { get; set; }
        public string Spesifikasi { get; set; }
        public decimal Jumlah { get; set; }
        public decimal HargaSatuan { get; set; }
        public decimal TotalHarga { get; set; }
        public decimal TotalOP { get; set; }
        public decimal PPN { get; set; }
        public decimal GrandTotalOP { get; set; }
        public string Negosiator { get; set; }
        public string Catatan { get; set; }
        public string MataUang { get; set; }
        public string Supplier { get; set; }
        public string Remarks { get; set; }
        public string Timeline { get; set; }
        public string Alasan { get; set; }
        public string Incoterm { get; set; }
        public string StatusBarang { get; set; }
        public string JadwalKirim { get; set; }
        public string Pembayaran { get; set; }
    }

    public class OpCompareHarga
    {
        [Key]
        public Int32 ID { get; set; }
        //public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public string Compare1 { get; set; }
        public string Compare2 { get; set; }
        public string Compare3 { get; set; }
        public string Compare4 { get; set; }
        public string Compare5 { get; set; }
    }

    public class OpHistorySpec
    {
        [Key]
        public Int32 ID { get; set; }
        public int Id_Ps_SPPBarangSub { get; set; }
        public int Id_Ps_SPPBarang { get; set; }
        public int Id_Ps_SPP { get; set; }
        public string Nomor_SPP { get; set; }
        public int Id_Ms_Barang { get; set; }
        public string Nama_Barang { get; set; }
        public int ID_Ms_GolonganBarang { get; set; }
        public string Nama_Golongan_Barang { get; set; }
        public int Id_Ps_OP { get; set; }
        public string Nomor_OP { get; set; }
        public int Id_Barang_SubLama { get; set; }
        public string Nama_Spek_Lama { get; set; }
        public int Id_Barang_SubDiv { get; set; }
        public string Nama_Spek_Div { get; set; }
        public int Id_Barang_SubBnC { get; set; }
        public string Nama_Spek_BnC { get; set; }
        public int Id_Barang_SubNego { get; set; }
        public string Nama_Spek_Nego { get; set; }
    }
}
