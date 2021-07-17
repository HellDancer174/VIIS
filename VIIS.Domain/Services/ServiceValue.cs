using ElegantLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Services
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ServiceValue: Notifier, IDocumentAsync, IEquatable<ServiceValue>
    {
        [JsonProperty("serviceValueID")] protected int id;
        [JsonProperty] protected string name;
        [JsonProperty("service_sale")] protected decimal sale;

        public ServiceValue(int id, string name, decimal sale)
        {
            this.id = id;
            this.name = name;
            this.sale = sale;
        }
        public ServiceValue(string name, decimal sale): this(0, name, sale)
        {
        }
        public ServiceValue(ServiceValue other): this(other.id, other.name, other.sale)
        {
        }
        public ServiceValue(): this("", 0)
        {
        }
        public virtual decimal Sale => sale;

        public override string ToString()
        {
            return name;
        }

        public Task TransferAsync()
        {
            return Task.CompletedTask;
        }


        public bool Equals(ServiceValue other)
        {
            return name == other.name && sale == other.sale;
        }

        public override bool Equals(object obj)
        {
            var other = obj as ServiceValue;
            return other != null && Equals(other);
        }
    }
}
