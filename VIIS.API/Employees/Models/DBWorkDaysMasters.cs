using ElegantLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.Decorators;

namespace VIIS.API.Employees.Models
{
    public class DBWorkDaysMasters : EmployeesDecorator, IDocument
    {
        private readonly IEnumerable<DBWorkDaysMaster> masters;
        private readonly List<string> failedMessages;

        public DBWorkDaysMasters(IEnumerable<DBWorkDaysMaster> masters) : base(new Domain.Staff.Employees(masters.Select(master => master as Master).ToList()))
        {
            this.masters = masters;
            failedMessages = new List<string>();
        }

        public void Transfer()
        {
            foreach(var master in masters)
            {
                master.Transfer();
                if (!master.IsSuccess) failedMessages.Add(master.FailedMessage());
            }
        }

        public bool IsSuccess => failedMessages.Count == 0;

        public string FailedMessage()
        {
            if (IsSuccess) return "";
            return string.Format("На эти даты назначены заказы: {0}", String.Join(", ", failedMessages));
        }
    }
}
