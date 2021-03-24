using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.Staff.ViewModels.EmployeesViewModels
{
    public class ViewAddress: Notifier
    {
        public ViewAddress(int index, string city, string street, string house, string flat)
        {
            Index = index;
            City = city;
            Street = street;
            House = house;
            Flat = flat;
        }
        public ViewAddress():this(0, nameof(City), nameof(Street), "0", "0")
        {
        }
        public int Index { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }

    }
}
