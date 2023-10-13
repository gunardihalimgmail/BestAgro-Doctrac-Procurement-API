using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.DTO.TTISApproval
{
    public class TTISDetail
    {
        [Key]
        public int id { get; set; }
        public string id_ps_ttis { get; set; }
        public string pt { get; set; }
        public string supplier { get; set; }
        public string nomor_ttis { get; set; }
        public string tanggal_ttis { get; set; }
        public string franco { get; set; }
        public string mata_uang { get; set; }
        public string nomor_op { get; set; }
        public string tanggal_op { get; set; }
        public string tipe_op { get; set; }
        public string total_op { get; set; }
        public string ppn { get; set; }
        public string tagihan { get; set; }
        public string tanggal_invoice { get; set; }
        public string status_barang { get; set; }
        public string waktu_antar { get; set; }
    }
}
