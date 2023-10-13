using AutoMapper;
using BestAgroCore.Common.Domain;
using BestAgroCore.Infrastructure.Data.EFRepositories.Contracts;
using Procurement.Domain.Aggregate.Penutupan;
using Procurement.Infrastructure;
using Procurement.WebAPI.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Commands.Penutupan
{
    public class UpdatePenutupanCommandHandler : ICommandHandler<UpdatePenutupanCommand>
    {
        private readonly IUnitOfWork<ProcurementContext> _uow;
        //private readonly IMapper _mapper;
        private readonly IPs_PenutupanRepository _ps_PenutupanRepository;
        private readonly IPs_SppRepository _ps_SppRepository;
        private readonly IPs_OPRepository _ps_OPRepository;
        private readonly IInv_PengeluaranBarangKeCabangLainRepository _inv_PengeluaranBarangKeCabangLainRepository;
        private readonly IPenutupanQueries _penutupanQueries;

        public UpdatePenutupanCommandHandler(IUnitOfWork<ProcurementContext> uow, IPs_PenutupanRepository ps_PenutupanRepository,
            IPenutupanQueries penutupanQueries, IPs_SppRepository ps_SppRepository,
            IPs_OPRepository ps_OPRepository, IInv_PengeluaranBarangKeCabangLainRepository inv_PengeluaranBarangKeCabangLainRepository) // ,IMapper mapper
        {
            _uow = uow;
            //_mapper = mapper;
            _ps_PenutupanRepository = ps_PenutupanRepository;
            _ps_SppRepository = ps_SppRepository;
            _ps_OPRepository = ps_OPRepository;
            _inv_PengeluaranBarangKeCabangLainRepository = inv_PengeluaranBarangKeCabangLainRepository;
            _penutupanQueries = penutupanQueries;
        }

        public async Task Handle(UpdatePenutupanCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // get user divisi
                var divisiName = await _penutupanQueries.GetDivisiName(command.ID_Ms_Login);

                if (command.Jenis.Equals("SPP"))
                {
                    var dataPenutupanSPP = await _penutupanQueries.GetDataPenutupan(command.ID, command.Jenis);
                    
                    if (command.FlagApproveOrReject.Equals("Approve"))
                    {
                        // Update table Ps_Penutupan
                        dataPenutupanSPP.TanggalApproved = DateTime.Now;

                        // update table Ps_Spp
                        var dataSPP = await _penutupanQueries.GetDataSPP(command.ID);
                        dataSPP.ID_Ms_Penutupan = dataPenutupanSPP.ID_Ms_Login;
                        dataSPP.TanggalPenutupan = dataPenutupanSPP.TanggalPenutupan;
                        dataSPP.PerihalPenutupan = dataPenutupanSPP.PerihalPenutupan;
                        dataSPP.AlasanPenutupan = dataPenutupanSPP.AlasanPenutupan;
                        _ps_SppRepository.Update(dataSPP);
                    }
                    else
                    {
                        dataPenutupanSPP.TanggalRejected = DateTime.Now;
                    }
                    
                    _ps_PenutupanRepository.Update(dataPenutupanSPP);
                    await _uow.CommitAsync();

                }
                else if (command.Jenis.Equals("OP"))
                {
                    var dataPenutupanOP = await _penutupanQueries.GetDataPenutupan(command.ID, command.Jenis);

                    if (command.FlagApproveOrReject.Equals("Approve"))
                    {
                        // Update table Ps_OP
                        dataPenutupanOP.TanggalApproved = DateTime.Now;

                        // update table Ps_Penutupan
                        var dataOP = await _penutupanQueries.GetDataOP(command.ID);
                        dataOP.ID_Ms_Penutupan = dataPenutupanOP.ID_Ms_Login;
                        dataOP.TanggalPenutupan = dataPenutupanOP.TanggalPenutupan;
                        dataOP.PerihalPenutupan = dataPenutupanOP.PerihalPenutupan;
                        dataOP.AlasanPenutupan = dataPenutupanOP.AlasanPenutupan;

                        _ps_OPRepository.Update(dataOP);
                    }
                    else
                    {
                        dataPenutupanOP.TanggalRejected = DateTime.Now;
                    }

                    _ps_PenutupanRepository.Update(dataPenutupanOP);
                    await _uow.CommitAsync();

                }
                else if (command.Jenis.Equals("SKBI"))
                {
                    var dataPenutupanSKBI = await _penutupanQueries.GetDataPenutupan(command.ID, command.Jenis);

                    if (command.FlagApproveOrReject.Equals("Approve"))
                    {
                        if (divisiName.Equals("DIR"))
                        {
                            dataPenutupanSKBI.TanggalApprovedDir = DateTime.Now;
                        }
                        else
                        {
                            dataPenutupanSKBI.TanggalApproved = DateTime.Now;
                        }

                        // update table Inv_PengeluaranBarangKeCabangLain
                        var dataSKBI = await _penutupanQueries.GetDataPengeluaranBarangKeCabangLain(command.ID);
                        dataSKBI.ID_Ms_Penutupan = dataPenutupanSKBI.ID_Ms_Login;
                        dataSKBI.TanggalPenutupan = dataPenutupanSKBI.TanggalPenutupan;
                        dataSKBI.PerihalPenutupan = dataPenutupanSKBI.PerihalPenutupan;
                        dataSKBI.AlasanPenutupan = dataPenutupanSKBI.AlasanPenutupan;

                        _inv_PengeluaranBarangKeCabangLainRepository.Update(dataSKBI);
                    }
                    else
                    {
                        if (divisiName.Equals("DIR"))
                        {
                            dataPenutupanSKBI.TanggalRejectedDir = DateTime.Now;
                        }
                        else
                        {
                            dataPenutupanSKBI.TanggalRejected = DateTime.Now;
                        }
                    }

                    _ps_PenutupanRepository.Update(dataPenutupanSKBI);
                    await _uow.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
