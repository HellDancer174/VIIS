using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIIS.Domain.Staff.ValueClasses
{
    public class EmployeeDetail
    {
        protected DateTime start;
        protected int contractID;

        public EmployeeDetail(DateTime start, int contractID)
        {
            this.start = start;
            this.contractID = contractID;
        }
        public EmployeeDetail(EmployeeDetail other): this(other.start, other.contractID)
        {
        }
        public EmployeeDetail() : this(DateTime.Now, 0)
        {
        }

    }
}
