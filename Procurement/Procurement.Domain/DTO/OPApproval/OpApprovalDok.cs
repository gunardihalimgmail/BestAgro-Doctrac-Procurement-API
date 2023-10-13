using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Procurement.Domain.DTO.OPApproval
{
    public class OpApprovalDok
    {
		public int ID { get; set; }
		public string Nomor { get; set; }
		public string Tanggal { get; set; }
		public string GolonganBarang { get; set; }
		public string Supplier { get; set; }
		public decimal GrandTotal { get; set; }
		public string MataUang { get; set; }
		[NotMapped]
		public string DokKey { get { return string.Format("{0}0{1}", this.Nomor, this.ID); } }
	}
}
