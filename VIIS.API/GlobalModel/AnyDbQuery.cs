using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VIIS.API.Data.DBObjects;

namespace VIIS.API.GlobalModel
{
    public sealed class AnyDBQuery<TEntity> : DBQuery<TEntity>
        where TEntity : class
    {
        public AnyDBQuery(VIISDBContext context) : base(/*new DbSet<TEntity>()*/null, context)
        {
        }
        public AnyDBQuery(): this(new VIISDBContext())
        {

        }

        public override void Transfer(TEntity entity)
        {
            
        }

        protected override void ExecuteCommand(TEntity entity)
        {
           
        }
    }
}
