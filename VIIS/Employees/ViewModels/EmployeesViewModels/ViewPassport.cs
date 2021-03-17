using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.Employees.ViewModels.EmployeesViewModels
{
    public class ViewPassport: ViewModel<String>
    {
        public ViewPassport(int seria, int passportID, DateTime date, string organization)
        {
            Seria = seria;
            PassportID = passportID;
            Date = date;
            Organization = organization;
        }
        public ViewPassport(): this(0,0, DateTime.Now, "")
        {
        }
        public int Seria { get; set; }
        public int PassportID { get; set; }
        public DateTime Date { get; set; }
        public string Organization { get; set; }

    }
}
