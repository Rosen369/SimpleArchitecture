using Dapper;
using SimpleArchitecture.Abstractions.Model;
using SimpleArchitecture.Abstractions.Repository;
using SimpleArchitecture.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Data;

namespace SimpleArchitecture.Repository
{
    public class SampleRepo : SqlRepo, ISampleRepo
    {
        protected override void SetCurrentRepoConnString()
        {
            this.ConnectionString = "some connection string";

        }

        public IList<SampleModel> GetByName(string name)
        {
            using (var conn = this.CreateSqlConnection())
            {
                var dp = new DynamicParameters();
                dp.Add("@Name", name);
                var sql = @"
                SELECT 
                    * 
                FROM 
                    Sample 
                WHERE
                    Name = @Name";
                var sampleList = conn.Query<SampleModel>(sql, param: dp, commandType: CommandType.Text).AsList();
                return sampleList;
            }
        }
    }
}
