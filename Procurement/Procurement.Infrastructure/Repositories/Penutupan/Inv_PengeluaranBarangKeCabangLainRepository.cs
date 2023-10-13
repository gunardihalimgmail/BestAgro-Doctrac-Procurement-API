using BestAgroCore.Infrastructure.Data.EFRepositories;
using Procurement.Domain.Aggregate.Penutupan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Infrastructure.Repositories.Penutupan
{
    public class Inv_PengeluaranBarangKeCabangLainRepository : EfRepository<Inv_PengeluaranBarangKeCabangLain>, IInv_PengeluaranBarangKeCabangLainRepository
    {
        private readonly ProcurementContext _context;

        public Inv_PengeluaranBarangKeCabangLainRepository(ProcurementContext context) : base(context)
        {
            _context = context;
        }
    }
}
