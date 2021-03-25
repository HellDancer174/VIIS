using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Staff.ValueClasses;
using VIIS.Domain.Staff.ValueClasses.Decorators;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels.EmployeesViewModels
{
    public class ViewAddress : DecoratableAddress
    {

        public ViewAddress() : this(new Address())
        {
        }

        public ViewAddress(Address other) : base(other)
        {
        }

        public int Index { get => index; set => index = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public string House { get => house; set => house = value; }
        public string Flat { get => flat; set => flat = value; }

    }
}
