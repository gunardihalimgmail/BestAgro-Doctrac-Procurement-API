using BestAgroCore.Common.Infrastructure.Data.Contracts;
using BestAgroCore.Infrastructure.Data.DapperRepositories;
using Procurement.Domain.Aggregate.ApprovalTTIS;
using Procurement.Domain.DTO.TTISApproval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procurement.WebAPI.Application.Queries
{
    public class TTISApprovalQueries : ITTISApprovalQueries
    {
        private readonly IDbSQLConectionFactory _dbConnectionFactorySQL;

        public TTISApprovalQueries(IDbSQLConectionFactory dbConnectionFactorySQL)
        {
            _dbConnectionFactorySQL = dbConnectionFactorySQL;
        }

        public async Task<List<TTISApproval>> GetOutstandingTTIS(int id_ms_login)
        {
            try
            {
                var qry = " EXEC usp_Dt_GetOutstandingTTIS @IdLogin = @p_id_ms_login; ";

                var data = await new DapperRepository<TTISApproval>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                     .QueryAsync(qry, new { p_id_ms_login = id_ms_login });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TTISDetail>> GetDetailTTIS(int id_ps_ttis)
        {
            try
            {
                var qry = " EXEC usp_Dt_GetDetailTTIS @IDTTIS = @p_id_ps_ttis; ";

                var data = await new DapperRepository<TTISDetail>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ps_ttis = id_ps_ttis });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LPBHistory>> GetHistoryLPB(int id_ps_ttis)
        {
            try
            {
                var qry = " EXEC usp_Dt_GetHistoryLPBTTIS @IDTTIS = @p_id_ps_ttis; ";

                var data = await new DapperRepository<LPBHistory>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ps_ttis = id_ps_ttis });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OPHistory>> GetHistoryOP(int id_ps_ttis)
        {
            try
            {
                var qry = " EXEC usp_Dt_GetHistoryOPTTIS @IDTTIS = @p_id_ps_ttis; ";

                var data = await new DapperRepository<OPHistory>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ps_ttis = id_ps_ttis });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Ps_TTIS> GetDataPsTTIS(int id_ps_ttis)
        {
            try
            {
                var qry = " select * from Ps_TTIS where ID_Ps_TTIS = @p_id_ps_ttis; ";

                var data = await new DapperRepository<Ps_TTIS>(_dbConnectionFactorySQL.GetDbConnection("JVE")) // DevEnv
                    .QueryAsync(qry, new { p_id_ps_ttis = id_ps_ttis });

                return data.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
