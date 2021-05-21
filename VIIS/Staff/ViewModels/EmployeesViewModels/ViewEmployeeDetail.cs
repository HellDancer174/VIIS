using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;
using VIMVVM;
using VIMVVM.Detail;

namespace VIIS.App.Staff.ViewModels.EmployeesViewModels
{
    public class ViewEmployeeDetail : DecoratableEmployeeDetail, IDetailedViewModel
    {

        public ViewEmployeeDetail() : this(new EmployeeDetail())
        {
        }

        public ViewEmployeeDetail(EmployeeDetail other) : base(other)
        {
        }

        public DateTime Start { get => start; set => start = value; }
        public int ContractID { get => contractID; set => contractID = value; }

        public void NotifySelector()
        {
            ChangeProperty(nameof(Start));
            ChangeProperty(nameof(ContractID));
        }
    }
}
