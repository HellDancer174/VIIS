using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff
{
    public class Employees
    {
        protected readonly List<Master> masters;

        public Employees(List<Master> masters)
        {
            this.masters = masters;
        }
        public Employees(Employees other)
        {
            masters = other.masters;
        }
        public Employees(): this(new List<Master>() { new Master()})
        {
        }
    }
}
