using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Procurement.Domain.Aggregate.ApprovalTTIS
{
	public class Ps_TTIS
	{
		[Key]
		public int ID_Ps_TTIS { get; set; }
		public int ID_Ms_UnitUsaha { get; set; }
		public int ID_Ms_Bagian { get; set; }
		public int ID_Ms_MataUang { get; set; }
		public string Nomor { get; set; }
		public string InvoiceSupplier { get; set; }
		public string Keterangan { get; set; }
		public DateTime? TanggalTerima { get; set; }
		public DateTime? TanggalJatuhTempo { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? TotalNetto { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Total { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? TotalPPN { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? TotalPPh { get; set; }
		public string ModifyStatus { get; set; }
		public string FlagInternal { get; set; }
		public string IsApproved { get; set; }
		public int IsApprovedBy { get; set; }
		public DateTime? IsApprovedTime { get; set; }
		public string FlagDPP { get; set; }
		public string FlagPajak { get; set; }
	}
}
