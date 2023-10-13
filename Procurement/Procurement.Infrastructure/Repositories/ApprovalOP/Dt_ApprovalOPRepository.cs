using BestAgroCore.Infrastructure.Data.EFRepositories;
using Procurement.Domain.Aggregate.ApprovalOP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procurement.Infrastructure.Repositories.ApprovalOP
{
    public class Dt_ApprovalOPRepository : EfRepository<Dt_ApprovalOP>, IDt_ApprovalOPRepository
    {
        private readonly ProcurementContext _context;

        public Dt_ApprovalOPRepository(ProcurementContext context) : base(context)
        {
            _context = context;
        }
    }
}
