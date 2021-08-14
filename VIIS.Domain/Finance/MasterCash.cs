using ElegantLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.Domain.Finance
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MasterCash: Notifier, IEquatable<Master>, IEquatable<MasterCash>, IDocumentAsync
    {
        [JsonProperty] protected Master master;
        [JsonProperty] protected DateTime startDate;
        [JsonProperty] protected DateTime finishDate;
        [JsonProperty] protected decimal value;

        public MasterCash(Master master, DateTime startDate, DateTime finishDate, decimal value)
        {
            this.master = master;
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.value = value;
        }
        public MasterCash(MasterCash other): this(other.master, other.startDate, other.finishDate, other.value)
        {
        }
        public MasterCash()
        {
            master = new Master();
        }

        public bool Equals(Master other)
        {
            return master.Equals(other);
        }

        public bool CheckMonth(DateTime monthDate)
        {
            return (startDate.Year == monthDate.Year && startDate.Month == monthDate.Month) || (finishDate.Year == monthDate.Year && finishDate.Year == monthDate.Month);
        }
        public bool HasCollision(DateTime otherStartDate, DateTime otherFinishDate)
        {
            return (startDate >= otherStartDate && startDate <= otherFinishDate) || (finishDate >= otherStartDate && finishDate <= otherFinishDate);
        }
        public bool CheckCollision(MasterCash other) => master.Equals(other.master) && HasCollision(other.startDate, other.finishDate);

        public bool Equals(MasterCash other)
        {
            return other != null && Equals(other.master) && value == other.value && startDate == other.startDate && finishDate == other.finishDate;
        }

        public override int GetHashCode()
        {
            var hashCode = 1988442695;
            hashCode = hashCode * -1521134295 + master.GetHashCode();
            hashCode = hashCode * -1521134295 + startDate.GetHashCode();
            hashCode = hashCode * -1521134295 + finishDate.GetHashCode();
            hashCode = hashCode * -1521134295 + value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return String.Format("Заработная плата: Мастер - {0}, период - c {1} по {2}, сумма - {3}", master.ToString(), startDate.ToShortDateString(), finishDate.ToShortDateString(), value);
        }

        public async Task TransferAsync()
        {
            await Task.CompletedTask;
        }

        public override bool Equals(object obj)
        {
            return obj is MasterCash && Equals((MasterCash)obj);
        }
    }
}
