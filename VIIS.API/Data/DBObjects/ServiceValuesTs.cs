using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class ServiceValuesTs
    {
        public ServiceValuesTs()
        {
            ServicesTt = new HashSet<ServicesTt>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sale { get; set; }

        public ICollection<ServicesTt> ServicesTt { get; set; }
    }
}
