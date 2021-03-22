using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Staff;
using VIIS.Domain.Staff.ValueClasses;

namespace VIIS.App.OrdersJournal.Models.EmployeesDecorators
{
    public class GroupedEmployees : Employees
    {
        private readonly Employees primary;

        public GroupedEmployees(Employees other) : base(other)
        {
            this.primary = other;
        }

        public ViewJournalEmployees ViewEmployees(DateTime workDay)
        {
            var mastersPosition = new Position("Мастер - парикмахер");
            var manicurePosition = new Position("Мастер маникюра");
            var pedicurePosition = new Position("Мастер педикюра");
            var masterList = masters.Where(master => master.Equals(mastersPosition) && master.IsWork(workDay)).Select(master => master.FullName).ToList();
            var manicureList = masters.Where(master => master.Equals(manicurePosition) && master.IsWork(workDay)).Select(master => master.FullName).ToList();
            var pedicureList = masters.Where(master => master.Equals(pedicurePosition) && master.IsWork(workDay)).Select(master => master.FullName).ToList();
            return new ViewJournalEmployees(manicureList, pedicureList, masterList);
        }
    }
}
