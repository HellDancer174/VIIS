using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.GlobalModel
{
    public class DBQueryWithSubQuery<TEntity> : DBQuery<TEntity>
        where TEntity : class
    {
        private readonly DBQuery<TEntity> query;
        private readonly DBQuery<TEntity> subQuery;

        /// <summary>
        /// query - запрос выполняющийся первым, subquery - запрос выполяющийся вторым
        /// </summary>
        /// <param name="query"></param>
        /// <param name="subQuery"></param>
        public DBQueryWithSubQuery(DBQuery<TEntity> query, DBQuery<TEntity> subQuery) : base(query)
        {
            this.query = query;
            this.subQuery = subQuery;
        }

        /// <summary>
        /// entity - сущность первого запроса, subEntry - сущность второго запроса
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="subEntry"></param>
        public void Transfer(TEntity entity, TEntity subEntry)
        {
            query.Transfer(entity);
            subQuery.Transfer(subEntry);
        }
    }
}
