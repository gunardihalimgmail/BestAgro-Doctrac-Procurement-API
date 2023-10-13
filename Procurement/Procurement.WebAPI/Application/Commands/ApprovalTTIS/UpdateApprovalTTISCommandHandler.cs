using BestAgroCore.Common.Domain;
using BestAgroCore.Infrastructure.Data.EFRepositories.Contracts;
using Procurement.Domain.Aggregate.ApprovalTTIS;
using Procurement.Infrastructure;
using Procurement.WebAPI.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Commands.ApprovalTTIS
{
    public class UpdateApprovalTTISCommandHandler : ICommandHandler<UpdateApprovalTTISCommand>
    {
        private readonly IUnitOfWork<ProcurementContext> _uow;
        private readonly ITTISApprovalQueries _ttisApprovalQueries;
        private readonly IPs_TTISRepository _ps_TTISRepository;

        public UpdateApprovalTTISCommandHandler(IUnitOfWork<ProcurementContext> uow,
            IPs_TTISRepository ps_TTISRepository,
            ITTISApprovalQueries ttisApprovalQueries)
        {
            _uow = uow;
            _ps_TTISRepository = ps_TTISRepository;
            _ttisApprovalQueries = ttisApprovalQueries;
        }

        public async Task Handle(UpdateApprovalTTISCommand command, CancellationToken cancellationToken)
        {
            try
            {
                DateTime now = DateTime.Now;
                var dataApprovalTTIS = await _ttisApprovalQueries.GetDataPsTTIS(command.id_ps_ttis);
                dataApprovalTTIS.IsApproved = "Y";
                dataApprovalTTIS.IsApprovedBy = command.id_ms_login;
                dataApprovalTTIS.IsApprovedTime = now;
                _ps_TTISRepository.Update(dataApprovalTTIS);
                await _uow.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string HandleError(string status)
        {
            throw new Exception(status);
        }
        
    }
}
