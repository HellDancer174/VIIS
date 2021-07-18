using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Finance;
//using VIIS.Domain.Finance.Decorators;

namespace VIIS.API.Finance
{
    public class DBTransaction : DecoratableTransaction, IDocument
    {
        private readonly DBQuery<TransactionsTt> query;
        private readonly TransactionsTt entity;

        public DBTransaction(Transaction other, DBQuery<TransactionsTt> query) : base(other)
        {
            this.query = query;
            entity = new TransactionsTt(id, name, sale);
        }
        public DBTransaction(TransactionsTt entity): this(new Transaction(entity.Id, entity.Name, entity.Sale), new AnyDBQuery<TransactionsTt>())
        {
        }

        public virtual void Transfer()
        {
            query.Transfer(entity);
        }
    }
}
