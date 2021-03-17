using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.Employees.ViewModels.EmployeesViewModels
{
    public class ViewEmployeeDetail: ViewModel<string>
    {
        private readonly ViewAddress address;
        private readonly ViewPassport passport;

        public ViewEmployeeDetail(ViewAddress address, ViewPassport passport, DateTime start, int contractID)
        {
            this.address = address;
            this.passport = passport;
            Start = start;
            ContractID = contractID;
        }
        public ViewEmployeeDetail():this(new ViewAddress(), new ViewPassport(), DateTime.Now, 0)
        {
        }

        public DateTime Start { get; set; }
        public int ContractID { get; set; }

        public ViewAddress Address => address;
        public ViewPassport Passport => passport;
    }
}
