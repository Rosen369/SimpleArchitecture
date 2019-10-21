using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SimpleArchitecture.Repository.Sql
{
    public abstract class SqlRepo
    {
        static SqlRepo()
        {
            Dapper.SqlMapper.Settings.CommandTimeout = 1800;
        }

        public SqlRepo()
        {
            this.SetCurrentRepoConnString();
        }

        public string ConnectionString { get; set; }

        protected abstract void SetCurrentRepoConnString();

        public IDbConnection CreateSqlConnection()
        {
            var connection = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
