using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class ServicesTt
    {
        public int ServiceValueId { get; set; }
        public int OrderId { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public OrdersTt Order { get; set; }
        public ServiceValuesTs ServiceValue { get; set; }
    }
}
