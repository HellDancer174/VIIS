using ElegantLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.GlobalModel
{
    public class DBQuery<TEntity>
        where TEntity: class
    {
        protected readonly DbSet<TEntity> collection;
        private readonly VIISDBContext context;

        public DBQuery(DbSet<TEntity> collection, VIISDBContext context)
        {
            this.collection = collection;
            this.context = context;
        }
        public DBQuery(DBQuery<TEntity> other): this(other.collection, other.context)
        {
        }

        protected virtual void ExecuteCommand(TEntity entity) => collection.Add(entity);

        public virtual void Transfer(TEntity entity)
        {
            ExecuteCommand(entity);
            context.SaveChanges();
        }
    }
}
