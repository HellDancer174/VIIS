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
    public class ViewPassport: DecoratablePassport, IDetailedViewModel<Passport>
    {
        public ViewPassport(): this(new Passport())
        {
        }

        public ViewPassport(Passport other) : base(other)
        {
        }

        public string Series { get => series; set => series = value; }
        public string PassportID { get => passportID; set => passportID = value; }
        public DateTime IssusiesDate { get => issusiesDate; set => issusiesDate = value; }
        public string Organization { get => organization; set => organization = value; }

        public Passport Model()
        {
            return new Passport(Series, PassportID, IssusiesDate, Organization);
        }

        public void NotifySelector()
        {
            ChangeProperty(nameof(Series));
            ChangeProperty(nameof(PassportID));
            ChangeProperty(nameof(IssusiesDate));
            ChangeProperty(nameof(Organization));

        }
    }
}
