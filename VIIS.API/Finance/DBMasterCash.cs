using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.Employees.Models;
using VIIS.API.GlobalModel;
using VIIS.Domain.Finance;
using VIIS.Domain.Finance.Decorators;

namespace VIIS.API.Finance
{
    public class DBMasterCash : DecoratableMasterCash, IDocument
    {
        protected readonly IEnumerable<MastersCashTt> mastersCashTts;
        private readonly DBQuery<MastersCashTt> query;
        protected readonly DBMaster dBMaster;
        private readonly MastersCashTt entity;

        public DBMasterCash(MasterCash other, IEnumerable<MastersCashTt> mastersCashTts, DBQuery<MastersCashTt> query) : base(other)
        {
            this.mastersCashTts = mastersCashTts;
            this.query = query;
            dBMaster = new DBMaster(master);
            entity = new MastersCashTt(dBMaster.Key, startDate, finishDate, value);
        }
        public DBMasterCash(DBMasterCash other): this(other, other.mastersCashTts, other.query)
        {

        }

        public virtual void Transfer()
        {
            query.Transfer(entity);
        }
    }
}
