using ElegantLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Finance
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Transaction: Notifier, IDocumentAsync, IEquatable<Transaction>
    {
        [JsonProperty] protected int id;
        [JsonProperty] protected string name;
        [JsonProperty] protected decimal sale;

        public Transaction(string name, decimal sale): this(0, name, sale)
        {
        }
        public Transaction(): this(nameof(name), 0)
        {
        }
        public Transaction(Transaction other): this(other.id, other.name, other.sale)
        {
        }
        public Transaction(int id, string name, decimal sale)
        {
            this.id = id;
            this.name = name;
            this.sale = sale;
        }

        public Transaction Sum(Transaction other)
        {
            return Sum(other, "Сумма");
        }
        
        public Transaction Sum(Transaction other, string name)
        {
            return new Transaction(name, sale + other.sale);
        }

        public bool IsCost()
        {
            return sale < 0;
        }

        public decimal Sale => sale;


        public virtual async Task TransferAsync()
        {
            await Task.CompletedTask;
        }

        public bool Equals(Transaction other)
        {
            if (other == null) return false;
            return name == other.name && sale == other.sale;
        }

        public override bool Equals(object obj)
        {
            return obj as Transaction != null && Equals(obj as Transaction);
        }

        public override int GetHashCode()
        {
            var hashCode = -960945004;
            hashCode = hashCode * -1521134295 + name.GetHashCode();
            hashCode = hashCode * -1521134295 + sale.GetHashCode();
            return hashCode;
        }
    }
}
