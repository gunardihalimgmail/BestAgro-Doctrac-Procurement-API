using BestAgroCore.Infrastructure.Data.EFRepositories;
using Procurement.Domain.Aggregate.Penutupan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Infrastructure.Repositories.Penutupan
{
    public class Ps_SppRepository : EfRepository<Ps_Spp>, IPs_SppRepository
    {
        private readonly ProcurementContext _context;

        public Ps_SppRepository(ProcurementContext context) : base(context)
        {
            _context = context;
        }
    }
}
