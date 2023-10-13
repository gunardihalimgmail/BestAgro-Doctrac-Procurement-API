using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Domain.DTO.ListOP.Request
{
    public class ListOPRequest
    {
        public string DokumenNo { get; set; }
        public List<string> Pt { get; set; }
        public string RequestDateFrom { get; set; }
        public string RequestDateTo { get; set; }
        public int IdLogin { get; set; }
    }
}
