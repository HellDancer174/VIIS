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
            viewAddress = new ViewAddress(address);
        }
        public ViewClient(): this(new Client())
        {
        }

        public ViewClient(ViewClient viewClient): base(viewClient)
        {
            viewAddress = new ViewAddress(address);
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                ChangeProperty(nameof(FullName));
            }
        }
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                ChangeProperty(nameof(FullName));
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                ChangeProperty(nameof(FullName));
            }
        }

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
        public string FullAddress => Address.ToString();
        public string Comment
        {
            get => comment;
            set
            {
                comment = value;
                ChangeProperty();
            }
        }



        public override bool Equals(object obj)
        {
            var client = obj as ViewClient;
            return client != null && Equals(client);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void ChangeProperties()
        {
            ChangeProperty(nameof(FullAddress));
        }
    }
}
