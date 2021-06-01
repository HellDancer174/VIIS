using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.Domain.Finance
{
    public class MasterCash: Notifier, IEquatable<Master>, IEquatable<MasterCash>, IDocumentAsync
    {
        protected readonly Master master;
        protected readonly DateTime startDate;
        protected readonly DateTime finishDate;
        protected readonly Transaction transaction;

        public MasterCash(Master master, DateTime startDate, DateTime finishDate, Transaction transaction)
        {
            this.master = master;
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.transaction = transaction;
        }
        public MasterCash(MasterCash other): this(other.master, other.startDate, other.finishDate, other.transaction)
        {
        }

        public bool Equals(Master other)
        {
            return master.Equals(other);
        }

        public bool CheckMonth(DateTime monthDate)
        {
            return (startDate.Year == monthDate.Year && startDate.Month == monthDate.Month) || (finishDate.Year == monthDate.Year && finishDate.Year == monthDate.Month);
        }
        public bool CheckCollision(MasterCash other)
        {
            return (startDate >= other.startDate && startDate < other.finishDate) || (finishDate > other.startDate && finishDate <= other.finishDate);
        }

        public bool Equals(MasterCash other)
        {
            return other != null && Equals(other.master) && transaction.Equals(other.transaction) && startDate == other.startDate && finishDate == other.finishDate;
        }

        public override int GetHashCode()
        {
            var hashCode = 1988442695;
            hashCode = hashCode * -1521134295 + master.GetHashCode();
            hashCode = hashCode * -1521134295 + startDate.GetHashCode();
            hashCode = hashCode * -1521134295 + finishDate.GetHashCode();
            hashCode = hashCode * -1521134295 + transaction.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return String.Format("Заработная плата: Мастер - {0}, период - c {1} по {2}, сумма - {2}", master.ToString(), startDate.ToShortDateString(), finishDate.ToShortDateString(), transaction.Sale);
        }

        public async Task Transfer()
        {
            await Task.CompletedTask;
        }
    }
}
