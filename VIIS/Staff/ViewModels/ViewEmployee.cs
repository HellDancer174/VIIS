using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Staff.ViewModels.EmployeesViewModels;
using VIIS.App.GlobalViewModel;
using VIMVVM;
using VIIS.Domain.Staff.Decorators;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewEmployee : DecoratableMaster
    {
        private readonly ViewEmployeeDetail viewDetail;
        private readonly ViewAddress viewAddress;
        private readonly ViewPassport viewPassport;

        public ViewEmployee(): this(new Master())
        {
        }

        public ViewEmployee(Master other) : base(other)
        {
            viewDetail = new ViewEmployeeDetail(detail);
            viewAddress = new ViewAddress(address);
            viewPassport = new ViewPassport(passport);
            Name = new ViewName(firstName, middleName, lastName);
        }

        public Position Position { get => position; set => position = value; }
        public ViewName Name { get; set; }
        public DateTime BirthDay { get => birthday; set => birthday = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }

        public ViewEmployeeDetail Detail => viewDetail;

        public ViewAddress Address => viewAddress;
        public ViewPassport Passport => viewPassport;
    }
}
