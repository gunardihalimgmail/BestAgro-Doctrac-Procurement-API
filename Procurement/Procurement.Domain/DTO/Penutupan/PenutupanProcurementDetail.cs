using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Domain.DTO.Penutupan
{
    public class PenutupanProcurementDetail
    {
        public int ID { get; set; }
        public string Flag { get; set; }
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public decimal Jumlah1 { get; set; }
        public decimal Jumlah2 { get; set; }
        public decimal Selisih { get; set; }
        public string Remark { get; set; }
        public string Pembuat { get; set; }
        public string Negosiator { get; set; }
        public string PerihalPenutupan { get; set; }
        public string AlasanPenutupan { get; set; }
    }
}
