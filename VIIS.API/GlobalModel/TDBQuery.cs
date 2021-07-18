using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VIIS.API.GlobalModel
{
    public class TDBQuery<TEntity>: DBQuery<TEntity>
        where TEntity : class
    {
        protected readonly new ICollection<TEntity> collection;

        public TDBQuery(ICollection<TEntity> collection): base(null, null)
        {
            this.collection = collection;
        }
        public TDBQuery(TDBQuery<TEntity> other) : this(other.collection)
        {
        }

        protected override void ExecuteCommand(TEntity entity) => collection.Add(entity);
        protected override void ExecuteCommand(IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities)
            {
                ExecuteCommand(entity);
            }
        }

        public override void Transfer(TEntity entity)
        {
            ExecuteCommand(entity);
        }
        public override void Transfer(IEnumerable<TEntity> entities)
        {
            ExecuteCommand(entities);
        }

    }
}
