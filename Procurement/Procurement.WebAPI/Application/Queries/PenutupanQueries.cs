using BestAgroCore.Common.Infrastructure.Data.Contracts;
using BestAgroCore.Infrastructure.Data.DapperRepositories;
using Procurement.Domain.Aggregate.Penutupan;
using Procurement.Domain.DTO.Penutupan;
using Procurement.Domain.DTO.Penutupan.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Queries
{
    public class PenutupanQueries : IPenutupanQueries
    {
        private readonly IDbSQLConectionFactory _dbConnectionFactorySQL;

        public PenutupanQueries(IDbSQLConectionFactory dbConnectionFactorySQL)
        {
            _dbConnectionFactorySQL = dbConnectionFactorySQL;
        }


        public async Task<List<PenutupanProcurement>> GetListPenutupan(int id_ms_login)
        {
            try
            {
                var qry = " EXEC usp_Dt_PenutupanProcurement @IdLogin = @p_id_ms_login; ";

                var data = await new DapperRepository<PenutupanProcurement>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ms_login = id_ms_login });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PenutupanProcurementDetail>> GetDetailPenutupan(PenutupanDetailRequest request)
        {
            try
            {
                var qry = " EXEC usp_Dt_PenutupanProcurementDetail @referensi = @p_referensi , @id = @p_id; ";

                var data = await new DapperRepository<PenutupanProcurementDetail>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_referensi = request.Referensi, p_id = request.ID });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetDivisiName(int id_ms_login)
        {
            try
            {
                var qry = " select div.Nama from Ms_Login log " +
                          "join Ms_Karyawan kar on log.ID_Ms_Karyawan = kar.ID_Ms_Karyawan " +
                          "join Ms_Divisi div on kar.ID_Ms_Divisi = div.ID_Ms_Divisi " +
                          "where log.ID_Ms_Login = @p_id_ms_login; ";

                var data = await new DapperRepository<string>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ms_login = id_ms_login });

                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Ps_Penutupan> GetDataPenutupan(int ID, string jenis)
        {
            try
            {
                var qry = " select * from Ps_Penutupan " +
                          "where JenisPenutupan = @p_jenis " +
                          "and ModifyStatus != 'D' " +
                          "and ID_Referensi = @p_id; ";

                var data = await new DapperRepository<Ps_Penutupan>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id = ID, p_jenis = jenis });

                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Ps_Spp> GetDataSPP(int id_ps_spp)
        {
            try
            {
                var qry = " select * from Ps_SPP " +
                          "where ID_Ps_SPP = @p_id_ps_spp; ";

                var data = await new DapperRepository<Ps_Spp>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ps_spp = id_ps_spp });

                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Ps_OP> GetDataOP(int id_ps_op)
        {
            try
            {
                var qry = " select * from Ps_OP " +
                          "where ID_Ps_OP = @p_id_ps_op; ";

                var data = await new DapperRepository<Ps_OP>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ps_op = id_ps_op });

                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Inv_PengeluaranBarangKeCabangLain> GetDataPengeluaranBarangKeCabangLain(int id_inv_pengeluaranbarangkecabanglain)
        {
            try
            {
                var qry = " select * from Inv_PengeluaranBarangKeCabangLain " +
                          "where ID_Inv_PengeluaranBarangKeCabangLain = @p_id_inv_pengeluaranbarangkecabanglain; ";

                var data = await new DapperRepository<Inv_PengeluaranBarangKeCabangLain>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_inv_pengeluaranbarangkecabanglain = id_inv_pengeluaranbarangkecabanglain });

                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
