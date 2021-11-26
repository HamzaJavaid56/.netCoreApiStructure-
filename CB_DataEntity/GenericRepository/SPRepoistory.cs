
using AF.DataEntities.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataEntity1.GenericRepository
{
    public  static class SPRepoistory<T> where T:class
    {        
        static SPRepoistory()
        {
        }
        public static string GetConnection()
        {
            var db = new SpContext();
            string conn_String = db.Database.GetDbConnection().ConnectionString;
            return conn_String;
        }
        public static List<T> GetListWithSp(string procedureName)
        {
            string conn_String = GetConnection();
            using (SqlConnection sqlCon = new SqlConnection(conn_String))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, commandType: System.Data.CommandType.StoredProcedure).ToList();              
            }               
        }
        public static List<T> GetListWithStoreProcedure(string proc,DynamicParameters obj)
        {
            string conn_String = GetConnection();
            using (SqlConnection sqlCon = new SqlConnection(conn_String))
            {
                //var parameters = new DynamicParameters();
                //parameters.Add("@customer_id", 3);     
                return sqlCon.Query<T>(proc, obj, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }           
    }
}
