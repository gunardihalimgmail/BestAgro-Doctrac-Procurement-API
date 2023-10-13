using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procurement.Domain.DTO.Penutupan
{
    public class PenutupanProcurement
    {
        [Key]
        public int ID_Ps_Penutupan { get; set; }
        public int ID { get; set; } // as ID_Ps_SPP || ID_Ps_OP || ID_Inv_PengeluaranBarangKeCabangLain
        public string Jenis { get; set; }
        public string Referensi { get; set; } // as Nomor ex: EST/SC1/SPP/19/05/00035 or EST/W1/OP/19/06/00050
        public string Tanggal { get; set; }
        public string KodeGolongan { get; set; }
        public string NamaGolongan { get; set; }
        public string Assignee { get; set; }
    }
}
