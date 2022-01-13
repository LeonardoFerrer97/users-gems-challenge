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
    public class TweetRepository : ITweetRepository
    {
        private readonly IDbConnection conn;
        public string connectionString;
        public TweetRepository(IOptions<ConnectionString> config)
        {

            connectionString = config.Value.DbConnection;
            conn = new NpgsqlConnection(connectionString);
        }
        public TweetRepository() { }
        public IEnumerable<TweetRetweet> GetTweets(int userId) {
            StringBuilder sb = new StringBuilder();
            var sql = sb.AppendFormat(TweetQueries.GET_TWEET_BY_FOLLOWER, userId);
            return SqlMapper.Query<TweetRetweet>(conn, sql.ToString());

        }
    }
}
