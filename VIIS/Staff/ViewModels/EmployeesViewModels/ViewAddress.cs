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
    public class ViewAddress : DecoratableAddress, IDetailedViewModel
    {
        //private readonly Action changeProperties;

        public ViewAddress() : this(new Address())
        {
        }

        public ViewAddress(Address other) : base(other)
        {
        }

        public int Index
        {
            get => index;
            set { index = value; }
        }
        public string City { get => city; set { city = value; } }
        public string Street { get => street; set { street = value; } }
        public string House { get => house; set { house = value; } }
        public string Flat { get => flat; set { flat = value; /*changeProperties.Invoke();*/ } }

        public void NotifySelector()
        {
            ChangeProperty(nameof(Index));
            ChangeProperty(nameof(City));
            ChangeProperty(nameof(Street));
            ChangeProperty(nameof(House));
            ChangeProperty(nameof(Flat));
        }
    }
}
