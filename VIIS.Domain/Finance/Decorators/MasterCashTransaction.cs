using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff;

namespace VIIS.Domain.Finance.Decorators
{
    public class MasterCashTransaction : DecoratableTransaction
    {
        protected readonly Master master;
        protected readonly DateTime startDate;
        protected readonly DateTime finishDate;

        public MasterCashTransaction(Transaction other, Master master, DateTime startDate, DateTime finishDate) : base(other)
        {
            this.master = master;
            this.startDate = startDate;
            this.finishDate = finishDate;
        }

        public bool Equals(Master other)
        {
            return master.Equals(other);
        }

        public bool CheckMonth(DateTime monthDate)
        {
            return (startDate.Year == monthDate.Year && startDate.Month == monthDate.Month) || (finishDate.Year == monthDate.Year && finishDate.Year == monthDate.Month);
        }
        public bool CheckCollision(MasterCashTransaction other)
        {
            return (startDate >= other.startDate && startDate < other.finishDate) || (finishDate > other.startDate && finishDate <= other.finishDate);
        }

        public bool Equals(MasterCashTransaction other)
        {
            return other != null && Equals(other.master) && base.Equals(other) && startDate == other.startDate && finishDate == other.finishDate;
        }

        public override int GetHashCode()
        {
            var hashCode = 1988442695;
            hashCode = hashCode * -1521134295 + master.GetHashCode();
            hashCode = hashCode * -1521134295 + startDate.GetHashCode();
            hashCode = hashCode * -1521134295 + finishDate.GetHashCode();
            hashCode = hashCode * -1521134295 + GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return String.Format("Заработная плата: Мастер - {0}, период - c {1} по {2}, сумма - {3}", master.ToString(), startDate.ToShortDateString(), finishDate.ToShortDateString(), Sale);
        }

        public override bool Equals(object obj)
        {
            return obj is MasterCash && Equals((MasterCashTransaction)obj);
        }

        public override async Task Transfer()
        {
            await Task.CompletedTask;
        }
    }
}
