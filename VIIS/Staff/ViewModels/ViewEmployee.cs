using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Staff.ViewModels.EmployeesViewModels;
using VIIS.App.GlobalViewModel;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels
{
    public class ViewEmployee: Notifier
    {
        private readonly ViewEmployeeDetail detail;

        public ViewEmployee(ViewEmployeeDetail detail, string position, ViewName name, DateTime birthDay, string phone, string email)
        {
            this.detail = detail;
            Position = position;
            Name = name;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
        }
        public ViewEmployee(): this(new ViewEmployeeDetail(), "", new ViewName(), DateTime.Now, "", "@mail")
        {
        }

        public string Position { get; set; }
        public ViewName Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ViewEmployeeDetail Detail => detail;
    }
}
