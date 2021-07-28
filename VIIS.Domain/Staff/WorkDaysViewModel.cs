using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.Domain.Staff;

namespace VIIS.Domain.Staff
{
    public class WorkDaysViewModel: IDocumentAsync
    {
        public WorkDaysViewModel(IEnumerable<Master> masters, DateTime month)
        {
            Masters = masters;
            Month = month;
        }

        public IEnumerable<Master> Masters { get; set; }
        public DateTime Month { get; set; }

        public Task TransferAsync()
        {
            throw new NotImplementedException();
        }
    }
}
