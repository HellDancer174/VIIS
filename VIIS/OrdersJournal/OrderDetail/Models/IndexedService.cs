using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.OrderDetail.Models
{
    public class IndexedService : Service
    {
        private readonly Service other;

        public IndexedService(Service other) : base(other)
        {
            this.other = other;
        }

        public int TimeIndex()
        {
            return start.Hours;
        }
    }
}
