using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.DTO.TTISApproval
{
    public class LPBHistory
    {
        [Key]
        public int id { get; set; }
        public string nomor_op { get; set; }
        public string tanggal_op { get; set; }
        public string total_op { get; set; }
        public string ppn { get; set; }
        public string nomor_lpb { get; set; }
        public string tanggal_lpb { get; set; }
        public string total_lpb { get; set; }
        public string approval_lpb { get; set; }
        public string nomor_ttis { get; set; }
        public string skbi { get; set; }
        public string total_skbi { get; set; }
        public string stbi { get; set; }
        public string total_stbi { get; set; }
    }
}
