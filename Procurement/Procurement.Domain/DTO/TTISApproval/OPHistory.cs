using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.DTO.TTISApproval
{
    public class OPHistory
    {
        [Key]
        public int id { get; set; }
        public string nomor_op { get; set; }
        public string tanggal_op { get; set; }
        public string nomor_lpb { get; set; }
        public string tanggal_lpb { get; set; }
        public string total_op { get; set; }
        public string pembayaran { get; set; }
        public string nomor_ttis { get; set; }
        public string tanggal_ttis { get; set; }
        public string nomor_bku { get; set; }
        public string tanggal_bku { get; set; }
        public string nomor_voucher { get; set; }
        public string tanggal_voucher { get; set; }
    }
}
