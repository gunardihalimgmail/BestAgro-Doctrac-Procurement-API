using BestAgroCore.Common.Infrastructure.Data.Contracts;
using Dapper;
using Procurement.Domain.DTO.ListOP;
using Procurement.Domain.DTO.ListOP.Request;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestAgroCore.Infrastructure.Data.DapperRepositories;
using Procurement.Domain.DTO.User;

namespace Procurement.WebAPI.Application.Queries
{
    public class ListOPQueries: IListOPQueries
    {
        private readonly IDbSQLConectionFactory _dbConnectionFactorySQL;
        
        public ListOPQueries(IDbSQLConectionFactory dbConnectionFactorySQL)
        {
            _dbConnectionFactorySQL = dbConnectionFactorySQL;
        }

        public async Task<UserDetail> GetUserInfo(int idLogin)
        {
            try
            {
                var qry = "select isnull(b.Nama, 'EST') as bagian, d.Nama as divisi " +
                    "from Ms_Login l with(nolock) " +
                    "join Ms_karyawan k with(nolock) on l.ID_Ms_Karyawan = k.ID_Ms_Karyawan " +
                    "join Ms_Bagian b with(nolock) on k.ID_Ms_Bagian = b.ID_Ms_Bagian " +
                    "join Ms_Divisi d with(nolock) on k.ID_Ms_Divisi = d.ID_Ms_Divisi " +
                    "where l.ModifyStatus != 'D' and l.ID_Ms_Login = @p_idLogin";

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@p_idLogin", idLogin, DbType.Int32, ParameterDirection.Input);

                var data = await new DapperRepository<UserDetail>(_dbConnectionFactorySQL.GetDbConnection("JVE"))
                    .QueryAsync(qry, parameters);

                UserDetail userDetail = new UserDetail();

                if (data != null && data.Any())
                {
                    userDetail.Bagian = data.FirstOrDefault().Bagian;
                    userDetail.Divisi = data.FirstOrDefault().Divisi;
                }

                return userDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ListOP>> GetListDokumenOp(ListOPRequest request)
        {
            try
            {
                //var qry = "usp_Dt_GetListDokumenOp";

                //DynamicParameters parameters = new DynamicParameters();

                //parameters.Add("@RequestDateFrom", request.RequestDateFrom, DbType.Date, ParameterDirection.Input);
                //parameters.Add("@RequestDateTo", request.RequestDateTo, DbType.Date, ParameterDirection.Input);
                //parameters.Add("@DokumenNo", request.DokumenNo, DbType.String, ParameterDirection.Input);
                //parameters.Add("@CsvKodePT", String.Join(",", request.Pt), DbType.String, ParameterDirection.Input);
                //parameters.Add("@IdLogin", request.IdLogin, DbType.Int32, ParameterDirection.Input);

                Console.WriteLine(request.RequestDateFrom);

                var qry_rev = "exec usp_Dt_GetListDokumenOp '" + request.RequestDateFrom + "', '" + request.RequestDateTo + "', '" + request.DokumenNo + "', '" + String.Join(",", request.Pt) + "', '" + request.IdLogin + "'";
                var data = await new DapperRepository<ListOP>(_dbConnectionFactorySQL.GetDbConnection("JVE"))
                    .QueryAsync(qry_rev);

                //var data = await new DapperRepository<ListOP>(_dbConnectionFactorySQL.GetDbConnection("JVE"))
                //    .QueryStoredProcedureAsync(qry, parameters);

                return data.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DocFlowStatusOP>> GetDocFlowStatusOP(DocFlowStatusOPRequest request)
        {
            try
            {
                var qry = "usp_Dt_GetDetailStatusOP";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DocNo", request.nomor, DbType.String);

                var data = await new DapperRepository<DocFlowStatusOP>(_dbConnectionFactorySQL.GetDbConnection("JVE"))
                         .QueryStoredProcedureAsync(qry, parameters);

                return data.ToList();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
