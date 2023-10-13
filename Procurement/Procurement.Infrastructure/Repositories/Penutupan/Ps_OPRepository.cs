using BestAgroCore.Infrastructure.Data.EFRepositories;
using Procurement.Domain.Aggregate.Penutupan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Infrastructure.Repositories.Penutupan
{
    public class Ps_OPRepository : EfRepository<Ps_OP>, IPs_OPRepository
    {
        private readonly ProcurementContext _context;

        public Ps_OPRepository(ProcurementContext context) : base(context)
        {
            _context = context;
        }
    }
}
