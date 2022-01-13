using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using User_gems_challenge_entity;
using User_gems_challenge_interface_repository;
using User_gems_challenge_utils;
using User_gems_challenge_utils.Queries;

namespace User_gems_challenge_repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection conn;
        public string connectionString;
        public UserRepository(IOptions<ConnectionString> config)
        {

            connectionString = config.Value.DbConnection;
            conn = new NpgsqlConnection(connectionString);
        }
        public IEnumerable<User> GetUsers(string name) {
            var sb = new StringBuilder();
            var sql = sb.AppendFormat(UserQueries.GET_USER_LIKE_NAME,name);
            return SqlMapper.Query<User>(conn,sql.ToString());

        }
    }
}
