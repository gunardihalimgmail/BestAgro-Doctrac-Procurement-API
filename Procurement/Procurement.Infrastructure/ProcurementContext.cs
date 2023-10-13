using Microsoft.EntityFrameworkCore;
using Procurement.Domain.Aggregate.ApprovalOP;
using Procurement.Domain.Aggregate.ApprovalTTIS;
using Procurement.Domain.Aggregate.Penutupan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Infrastructure
{
    public partial class ProcurementContext : DbContext
    {
        public ProcurementContext()
        {

        }

        public ProcurementContext(DbContextOptions<ProcurementContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        // Db Set untuk Transaksi CRUD
        public virtual DbSet<Dt_ApprovalOP> Dt_ApprovalOP { get; set; }
        public virtual DbSet<Ps_Penutupan> Ps_Penutupan { get; set; }
        public virtual DbSet<Ps_Spp> Ps_Spp { get; set; }
        public virtual DbSet<Ps_OP> Ps_OP { get; set; }
        public virtual DbSet<Inv_PengeluaranBarangKeCabangLain> Inv_PengeluaranBarangKeCabangLain { get; set; }
        public virtual DbSet<Ps_TTIS> Ps_TTIS { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
