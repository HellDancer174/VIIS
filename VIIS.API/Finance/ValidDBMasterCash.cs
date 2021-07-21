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
        private ValidID validID;

        public ValidDBMasterCash(DBMasterCash other, Func<int, bool> validateID) : base(other)
        {
            validID = new ValidID("masterID", dBMaster.Key, validateID);
            this.primary = other;
        }

        public override void Transfer()
        {
            validID.Validate();
            var monthCashes = mastersCashTts.Where(cash => CheckMonth(cash.FinishDate) && cash.MasterId == dBMaster.Key).ToArray();
            foreach (var cash in monthCashes)
            {
                if (HasCollision(cash.StartDate, cash.FinishDate)) throw new ArgumentException(String.Format("Найдена коллизия: Мастер - {0}, начало периода - {1}, конец периода - {2}", master.FullName, startDate, finishDate));
            }
            primary.Transfer();
        }
    }
}
