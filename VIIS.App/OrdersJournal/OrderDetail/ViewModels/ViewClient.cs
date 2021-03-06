using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.OrderDetail.Models;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewClient : ClientDecorator
    {

        public ViewClient(Client other): base(other)
        {

        }
        public Client Model()
        {
            return this;
        }

        public bool IsAnyClient => String.IsNullOrEmpty(firstName) && String.IsNullOrEmpty(middleName) && String.IsNullOrEmpty(lastName) && id == -1;


        public void Clear()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
        }

        public override bool Equals(object obj)
        {
            var client = obj as ViewClient;
            return client != null && Equals(client);
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                ChangeProperty();
            }
        }
        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
                ChangeProperty();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                ChangeProperty();
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
    }
}
