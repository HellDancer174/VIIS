using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.API.Data.DBObjects;
using VIIS.API.GlobalModel;
using VIIS.Domain.Finance;

namespace VIIS.API.Finance
{
    public class ValidDBMasterCash : DBMasterCash
    {
        private readonly DBMasterCash primary;

        public ValidDBMasterCash(DBMasterCash other) : base(other)
        {
            this.primary = other;
        }

        public override void Transfer()
        {
            var monthCashes = mastersCashTts.Where(cash => CheckMonth(cash.FinishDate) && cash.MasterId == dBMaster.Key).ToArray();
            foreach (var cash in monthCashes)
            {
                if (HasCollision(cash.StartDate, cash.FinishDate)) throw new ArgumentException(String.Format("Найдена коллизия: Мастер - {0}, начало периода - {1}, конец периода - {2}", master.FullName, startDate, finishDate));
            }
            primary.Transfer();
        }
    }
}
