using BestAgroCore.Infrastructure.Data.EFRepositories;
using Procurement.Domain.Aggregate.Penutupan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Infrastructure.Repositories.Penutupan
{
    public class Ps_PenutupanRepository : EfRepository<Ps_Penutupan>, IPs_PenutupanRepository
    {
        private readonly ProcurementContext _context;

        public Ps_PenutupanRepository(ProcurementContext context) : base(context)
        {
            _context = context;
        }
    }
}
