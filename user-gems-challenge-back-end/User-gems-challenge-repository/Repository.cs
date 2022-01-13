using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using User_gems_challenge_utils;
using Npgsql;
using System.Transactions;
using User_gems_challenge_interface_repository;
using User_gems_challenge_interface_repository.Infraestruture;
using User_gems_challenge_repository.Infraestruture;
using System;
using Microsoft.Extensions.Options;

namespace User_gems_challenge_repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection conn;
        /// <summary>
        /// Manager Qry Constructor.
        /// </summary>
        public IPartsQryGenerator<TEntity> partsQryGenerator { private get; set; }
        /// <summary>
        /// Manager to worker with Identified Fields
        /// </summary>
        public IIDentityInspector<TEntity> identityInspector { private get; set; }

        /// <summary>
        /// Idetenfier parameter (@) to SqlServer (:) to Oracle
        /// </summary>
        public char ParameterIdentified { get; set; }


        protected string qrySelect { get; set; }
        protected string qryInsert { get; set; }


        public string connectionString;
        private string identityField;


        /// <summary>
        /// Create a GenericRepository for Dapper
        /// </summary>
        /// <param name="conn">Connection</param>
        /// <param name="parameterIdentified">Idetenfier parameter (@) to SqlServer (:) to Oracle</param>
        public Repository(IOptions<ConnectionString> config, char parameterIdentified = '@')
        {

            connectionString = config.Value.DbConnection;
            conn = new NpgsqlConnection(connectionString);
            ParameterIdentified = parameterIdentified;
            partsQryGenerator = new PartsQryGenerator<TEntity>(ParameterIdentified);
            identityInspector = new IDentityInspector<TEntity>(conn);
        }
        public Repository() { }

        #region Creates Qries

        protected virtual void CreateSelectQry()
        {
            if (string.IsNullOrWhiteSpace(qrySelect))
            {
                qrySelect = partsQryGenerator.GenerateSelect();
            }
        }

        protected virtual void CreateInsertQry()
        {
            if (string.IsNullOrWhiteSpace(qryInsert))
            {
                identityField = identityInspector.GetColumnsIdentityForType();

                qryInsert = partsQryGenerator.GeneratePartInsert(identityField);
            }
        }

        #endregion


        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>All entities</returns>
        #region All/Async

        public IEnumerable<TEntity> All()
        {
            CreateSelectQry();
            IEnumerable<TEntity> result = SqlMapper.Query<TEntity>(conn, qrySelect);
            return result;

        }

        /// <summary>
        /// Get Async all entities
        /// </summary>
        /// <returns>All entities</returns>
        public Task<IEnumerable<TEntity>> AllAsync()
        {
            return Task.Run(() =>
            {
                return All();
            });
        }


        #endregion

        #region GetData/Async

        /// <summary>
        /// Get Entities in DB from qry with object parameters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Entities for this filter</returns>
        public IEnumerable<TEntity> GetData(string qry, object parameters)
        {
            var result = conn.Query<TEntity>(qry, parameters);

            return result;
        }

        /// <summary>
        /// Get async Entities in DB from qry with object parameters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Entities for this filter</returns>
        public Task<IEnumerable<TEntity>> GetDataAsync(string qry, object parameters)
        {

            var result = conn.QueryAsync<TEntity>(qry, parameters);

            return result;
        }

        /// <summary>
        /// Get Entities in DB from a object filter (equals property with value) 
        /// Example:  new { Name = "Peter", Age = 18 } --> Select * ... Where Name = 'Peter' and Age = 18
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Entities for this filter</returns>
        public IEnumerable<TEntity> GetData(object filter)
        {

            var selectQry = partsQryGenerator.GenerateSelect(filter);

            var result = conn.Query<TEntity>(selectQry, filter);

            return result;
        }

        /// <summary>
        /// Get async Entities in DB from a object filter (equals property with value) (DP)
        /// Example:  new { Name = "Peter", Age = 18 } --> Select * ... Where Name = 'Peter' and Age = 18
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Task with Entities for this filter</returns>
        public Task<IEnumerable<TEntity>> GetDataAsync(object filter)
        {
            return Task.Run(() =>
            {
                return GetData(filter);
            });
        }

        #endregion

        #region Find/Async

        /// <summary>
        /// Find entity in DB for PK
        /// </summary>
        /// <param name="pksFields">Object with pk properties</param>
        /// <returns>Entity for pk values</returns>
        public TEntity Find(object pksFields)
        {

            var selectQry = partsQryGenerator.GenerateSelect(pksFields);

            var result = conn.Query<TEntity>(selectQry, pksFields).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Find Async entity in DB for PK
        /// </summary>
        /// <param name="pksFields">Object with pk properties</param>
        /// <returns>Entity for pk values</returns>
        public Task<TEntity> FindAsync(object pksFields)
        {
            return Task.Run(() =>
            {
                return Find(pksFields);
            });
        }

        #endregion

        #region Add/Async

        /// <summary>
        /// Add a new Entity in DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number changes in DB</returns>
        public int Add(TEntity entity)
        {
            if (conn == null) throw new ArgumentNullException(nameof(entity), $"The parameter {nameof(entity)} can't be null");

            CreateInsertQry();
            using (conn)
            {
                int result = conn.Execute(qryInsert, entity);


                return result;
            }
        }


        /// <summary>
        /// Add Async a new Entity in DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number changes in DB</returns>
        public Task<int> AddAsync(TEntity entity)
        {
            if (conn == null) throw new ArgumentNullException(nameof(entity), $"The parameter {nameof(entity)} can't be null");

            CreateInsertQry();

            var result = conn.ExecuteAsync(qryInsert, entity);

            return result;

        }


        /// <summary>
        /// Add a Sequence of items in BulkInsert
        /// </summary>
        /// <param name="entities">Sequence of entities</param>
        /// <returns>number changes in DB</returns>
        public int Add(IEnumerable<TEntity> entities)
        {

            CreateInsertQry();

            int result = conn.Execute(qryInsert, entities);

            return result;
        }

        /// <summary>
        /// Add Async a Sequence of items in BulkInsert (DP)
        /// </summary>
        /// <param name="entities">Sequence of entities</param>
        /// <returns>number changes in DB</returns>
        public Task<int> AddAsync(IEnumerable<TEntity> entities)
        {

            CreateInsertQry();

            var result = conn.ExecuteAsync(qryInsert, entities);

            return result;
        }

        #endregion

        #region Remove/Async

        public void Remove(object key)
        {

            var deleteQry = partsQryGenerator.GenerateDelete(key);

            conn.Execute(deleteQry, key);
        }

        public Task RemoveAsync(object key)
        {

            var deleteQry = partsQryGenerator.GenerateDelete(key);

            return conn.ExecuteAsync(deleteQry, key);
        }


        #endregion

        #region Update/Async

        public int Update(TEntity entity, object pks)
        {

            var updateQry = partsQryGenerator.GenerateUpdate(pks);

            var result = conn.Execute(updateQry, entity);

            return result;
        }

        public Task<int> UpdateAsync(TEntity entity, object pks)
        {
            var updateQry = partsQryGenerator.GenerateUpdate(pks);

            var result = conn.ExecuteAsync(updateQry, entity);

            return result;
        }

        #endregion

        #region InsertOrUpdate/Async

        public int InstertOrUpdate(TEntity entity, object pks)
        {

            int result = 0;

            var entityInTable = Find(pks);

            if (entityInTable == null)
            {
                result = Add(entity);
            }
            else
            {
                result = Update(entity, pks);
            }

            return result;
        }

        public Task<int> InstertOrUpdateAsync(TEntity entity, object pks)
        {
            return Task.Run(() => InstertOrUpdate(entity, pks));
        }


        #endregion


        public void Dispose() { }

    }
}
