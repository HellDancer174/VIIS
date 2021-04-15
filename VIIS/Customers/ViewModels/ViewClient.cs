using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.App.Staff.ViewModels.EmployeesViewModels;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewClient : ClientDecorator
    {
        private readonly ViewAddress viewAddress;

        public ViewClient(Client other) : base(other)
        {
            Name = new ViewName(firstName, middleName, lastName);
            viewAddress = new ViewAddress(address);
        }
        public ViewClient(): this(new Client())
        {
        }

        public ViewClient(ViewClient viewClient): base(viewClient)
        {
            Name = new ViewName(firstName, middleName, lastName);
            viewAddress = new ViewAddress(address);
        }

        public ViewName Name { get; set; }
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                ChangeProperty();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                if (value == email) return;
                email = value;
                ChangeProperty();
                
            }
        }


        public ViewAddress Address => viewAddress;
        public string FullAddress => address.ToString();
        public string Comment { get => comment; set => comment = value; }

        public void ChangeProperties()
        {
            ChangeProperty(nameof(Name));
            ChangeProperty(nameof(Phone));
            ChangeProperty(nameof(Email));
            ChangeProperty(nameof(FullAddress));
            ChangeProperty(nameof(Comment));

        }
    }
}
