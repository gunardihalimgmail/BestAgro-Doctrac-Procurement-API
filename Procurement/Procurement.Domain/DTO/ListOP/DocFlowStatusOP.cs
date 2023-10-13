using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.DTO.ListOP
{
    public class DocFlowStatusOP
    {
        [Key]
        public int ID { get; set; }
        public string Level { get; set; }
        public string Supplier { get; set; }
        public string Nomor { get; set; }
        public string TanggalStr { get; set; }
        public string IsApproved { get; set; }
        public string IsApprovedByName { get; set; }
        public string IsApprovedTimeStr { get; set; }
        public string KeteranganApproved { get { return string.Format("{0} / {1}", IsApproved, IsApprovedTimeStr); } }
        public string Keterangan { get { return string.Format("{0} / {1}", Nomor, IsApprovedByName); } }
        public string LevelStyle { get { return string.Format("level{0}", Level); } }
    }
}
