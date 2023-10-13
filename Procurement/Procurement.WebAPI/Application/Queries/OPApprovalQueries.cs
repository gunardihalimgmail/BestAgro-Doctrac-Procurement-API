using BestAgroCore.Common.Infrastructure.Data.Contracts;
using BestAgroCore.Infrastructure.Data.DapperRepositories;
using Procurement.Domain.Aggregate.ApprovalOP;
using Procurement.Domain.DTO.OPApproval;
using Procurement.Domain.DTO.OPApproval.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Queries
{
    public class OPApprovalQueries : IOPApprovalQueries
    {
        private readonly IDbSQLConectionFactory _dbConnectionFactorySQL;

        public OPApprovalQueries(IDbSQLConectionFactory dbConnectionFactorySQL)
        {
            _dbConnectionFactorySQL = dbConnectionFactorySQL;
        }


        public async Task<List<OpApprovalDok>> GetListOP(int id_ms_login)
        {
            try
            {
                var qry = " EXEC usp_Dt_ApprovalOP @IdLogin = @p_id_ms_login; ";

                var data = await new DapperRepository<OpApprovalDok>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ms_login = id_ms_login });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OpApprovalDetail> GetListDetail(OpApprovalDetailRequest request)
        {
            try
            {
                var qry = " EXEC usp_Dt_ApprovalOPDetail @IdOP = @p_id_ps_op, @IdLogin = @p_id_ms_login; ";

                var data = new DapperRepository<OpApprovalDetail>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .Query(qry, new { p_id_ps_op = request.id_ps_op, p_id_ms_login = request.id_ms_login });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OpCompareHarga> GetListCompare(int id_ps_op)
        {
            try
            {
                var qry = " EXEC usp_Dt_PerbandinganHargaOP @IdOP = @p_id_ps_op; ";

                var data = new DapperRepository<OpCompareHarga>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .Query(qry, new { p_id_ps_op = id_ps_op});

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OpCompareHarga> GetListCompareSpesifikasi(int id_ps_op)
        {
            try
            {
                var qry = " EXEC usp_Dt_PerbandinganHargaOP2 @IdOP = @p_id_ps_op; ";

                var data = new DapperRepository<OpCompareHarga>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .Query(qry, new { p_id_ps_op = id_ps_op });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OpHistorySpec> GetListPerubahanSpec(int id_ps_op)
        {
            try
            {
                var qry = " EXEC usp_GetHistoryPerubahanSpec @id_op = @p_id_ps_op; ";

                var data = new DapperRepository<OpHistorySpec>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .Query(qry, new { p_id_ps_op = id_ps_op });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserRoleOp> GetJenisUserApproval(int id_ms_login)
        {
            try
            {
                var qry = " EXEC usp_Dt_JenisUserApprovalOP @IdLogin = @p_id_ms_login; ";

                var data = await new DapperRepository<UserRoleOp>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ms_login = id_ms_login });

                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Dt_ApprovalOP> GetDataApprovalOP(int id_ps_op)
        {
            try
            {
                var qry = " select * from Dt_ApprovalOP where ID_Ps_OP = @p_id_ps_op; ";

                var data = await new DapperRepository<Dt_ApprovalOP>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ps_op = id_ps_op });

                return data.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
