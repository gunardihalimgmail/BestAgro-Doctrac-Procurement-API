using BestAgroCore.Infrastructure.Data.EFRepositories;
using Procurement.Domain.Aggregate.ApprovalTTIS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Infrastructure.Repositories.ApprovalTTIS
{
    public class Ps_TTISRepository : EfRepository<Ps_TTIS>, IPs_TTISRepository
    {
        private readonly ProcurementContext _context;

        public Ps_TTISRepository(ProcurementContext context) : base(context)
        {
            _context = context;
        }
    }
}
