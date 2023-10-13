using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Procurement.Domain.DTO.ListOP
{
    public class ListOP
    {
        [Key]
        public int ID { get; set; }
        public string Jenis { get; set; }
        public string PT { get; set; }
        public string NomorOp { get; set; }
        public string Supplier { get; set; }
        public string TipeOP { get; set; }
        public int? JatuhTempo { get; set; }
        public string Franco { get; set; }
        public string? IsApproved { get; set; }
        public int? IsApprovedBy { get; set; }
        public string? IsApprovedByName { get; set; }
        public DateTime? IsApprovedTime { get; set; }
        public string? IsApprovedTimeStr { get; set; }
    }
}
