using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Staff.ViewModels.EmployeesViewModels;
using VIIS.Domain.Global;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;

namespace VIIS.App.Staff.Models
{
    public class DetailOfView : DecoratableEmployeeDetail
    {
        private ValidProperty<int> validContractID;
        private ValidProperty<DateTime> validStart;

        public DetailOfView(EmployeeDetail other) : base(other)
        {
            validContractID = new ValidProperty<int>("Номер договора", contractID, contractID > 0);
            validStart = new ValidProperty<DateTime>("Дата приема на работу", start, start != new DateTime());
        }

        public bool Safe()
        {
            try
            {
                validContractID.Validate();
                validStart.Validate();
                return true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


    }
}
