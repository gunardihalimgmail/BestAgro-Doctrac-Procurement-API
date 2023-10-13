using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Procurement.Domain.DTO.ListOP
{
    public class ListOPDetail
    {
        [Key]
        public int ID { get; set; }
        public string? isApproved { get; set; }
        public string? isApprovedByName { get; set; }
        public string? isApprovedTimeStr { get; set; }
        public string keterangan { get; set; }
        public string keteranganApproved { get; set; }
        public string level { get; set; }
        public string levelStyle { get; set; }
        public string nomor { get; set; }
        public string supplier { get; set; }
        public string tanggalStr { get; set; }

    }
}
