using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.DTO.TTISApproval
{
    public class TTISApproval
    {
        [Key]
        public int id { get; set; }
        public string pt { get; set; }
        public string tanggal_ttis { get; set; }
        public string nomor_ttis { get; set; }
        public string invoice_supplier { get; set; }
        public string mata_uang { get; set; }
        public string nilai_invoice { get; set; }
        public string ppn { get; set; }
        public string negosiator { get; set; }
        public string dok_key { get { return string.Format("{0}0{1}", "ttis", this.id.ToString()); } }
    }
}
