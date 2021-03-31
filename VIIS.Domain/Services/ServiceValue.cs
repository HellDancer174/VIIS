using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.Domain.Services
{
    public class ServiceValue: Notifier, IDocumentAsync, IEquatable<ServiceValue>
    {
        protected string name;
        protected decimal sale;

        public ServiceValue(string name, decimal sale)
        {
            this.name = name;
            this.sale = sale;
        }
        public ServiceValue(ServiceValue other)
        {
            name = other.name;
            sale = other.sale;
        }
        public ServiceValue(): this("", 0)
        {
        }
        public virtual decimal Sale => sale;

        public override string ToString()
        {
            return name;
        }

        public Task Transfer()
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
