using AutoMapper;
using BestAgroCore.Common.Domain;
using BestAgroCore.Infrastructure.Data.EFRepositories.Contracts;
using Procurement.Domain.Aggregate.ApprovalOP;
using Procurement.Infrastructure;
using Procurement.WebAPI.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Commands.ApprovalOP
{
    public class UpdateApprovalOPCommandHandler : ICommandHandler<UpdateApprovalOPCommand>
    {
        private readonly IUnitOfWork<ProcurementContext> _uow;
        //private readonly IMapper _mapper;
        private readonly IDt_ApprovalOPRepository _Dt_ApprovalOPRepository;
        private readonly IOPApprovalQueries _OPApprovalQueries;

        public UpdateApprovalOPCommandHandler(IUnitOfWork<ProcurementContext> uow,
            IDt_ApprovalOPRepository Dt_ApprovalOPRepository,
            IOPApprovalQueries OPApprovalQueries) // ,IMapper mapper
        {
            _uow = uow;
            //_mapper = mapper;
            _Dt_ApprovalOPRepository = Dt_ApprovalOPRepository;
            _OPApprovalQueries = OPApprovalQueries;
        }


        public async Task Handle(UpdateApprovalOPCommand command, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var item in command.ID_Ps_OP)
                {
                    // get user role
                    var cekJenisUser = await _OPApprovalQueries.GetJenisUserApproval(command.ID_Ms_Login);
                    var dataApprovalOP = await _OPApprovalQueries.GetDataApprovalOP(Int32.Parse(item));

                    if (cekJenisUser.ID != null && !String.IsNullOrEmpty(cekJenisUser.Jenis))
                    {

                        if (cekJenisUser.Jenis == "MANAGER PKS")
                        {
                            dataApprovalOP.IDLoginFactory = cekJenisUser.ID;
                            dataApprovalOP.TanggalApprovalFactory = DateTime.Now;
                        }
                        else if (cekJenisUser.Jenis == "MANAGER PROCUREMENT")
                        {
                            dataApprovalOP.IDLoginManager = cekJenisUser.ID;
                            dataApprovalOP.TanggalApprovalManager = DateTime.Now;
                        }
                        else if (cekJenisUser.Jenis == "DIREKTUR")
                        {
                            dataApprovalOP.IDLoginDirektur = cekJenisUser.ID;
                            dataApprovalOP.TanggalApprovalDirektur = DateTime.Now;
                        }

                        _Dt_ApprovalOPRepository.Update(dataApprovalOP);
                    }
                    else
                    {
                        HandleError("OP hanya bisa di approve oleh Negosiator / Manager / Direktur!");
                    }
                }
                
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string HandleError(string status)
        {
            throw new Exception(status);
        }
    }
}
