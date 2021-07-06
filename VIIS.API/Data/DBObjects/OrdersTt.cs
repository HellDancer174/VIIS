using System;
using System.Collections.Generic;

namespace VIIS.API.Data.DBObjects
{
    public partial class OrdersTt
    {
        public OrdersTt()
        {
            ServicesTt = new HashSet<ServicesTt>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public DateTime Start { get; set; }
        public decimal Sale { get; set; }
        public int IsFinished { get; set; }
        public string Comment { get; set; }

        public PersonsTt Client { get; set; }
        public EmployeesTt Master { get; set; }
        public ICollection<ServicesTt> ServicesTt { get; set; }
    }
}
