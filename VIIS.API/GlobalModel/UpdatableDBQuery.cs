using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.GlobalModel
{
    public class UpdatableDBQuery<TEntity> : DBQuery<TEntity>
        where TEntity : class
    {
        public UpdatableDBQuery(DbSet<TEntity> collection, VIISDBContext context) : base(collection, context)
        {
        }

        protected override void ExecuteCommand(TEntity entity) => collection.Update(entity);
    }
}
