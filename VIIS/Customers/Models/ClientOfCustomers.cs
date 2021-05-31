using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.OrdersJournal.OrderDetail.Models.Validatable;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIIS.Domain.Global;

namespace VIIS.App.Customers.Models
{
    public class ClientOfCustomers : ClientDecorator
    {
        private readonly ClientOfJournal clientOfJournal;
        private readonly ValidProperty<string> validMiddleName;

        public ClientOfCustomers(ClientOfJournal other) : base(other)
        {
            this.clientOfJournal = other;
            validMiddleName = new ValidProperty<string>("Отчество", middleName, !(String.IsNullOrEmpty(middleName) || String.IsNullOrWhiteSpace(middleName)));
        }

        public Client Safe()
        {
            try
            {
                validMiddleName.Validate();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return clientOfJournal.Safe();
        }

        public Client UnSafe()
        {
            validMiddleName.Validate();
            return clientOfJournal.UnSafe();
        }
    }
}
