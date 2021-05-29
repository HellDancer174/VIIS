using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIIS.Domain.Global;

namespace VIIS.App.OrdersJournal.OrderDetail.Models.Validatable
{
    public class ClientOfJournal : ClientDecorator
    {
        private ValidProperty<string> validFirstName;
        private ValidProperty<string> validLastName;
        private ValidProperty<string> validPhone;


        public ClientOfJournal(Client other) : base(other)
        {
            Func<string, bool> condition = (strValue) => !(String.IsNullOrEmpty(strValue) || String.IsNullOrWhiteSpace(strValue));
            validFirstName = new ValidProperty<string>("Имя", firstName, condition(firstName));
            validLastName = new ValidProperty<string>("Фамилия", lastName, condition(lastName));
            validPhone = new ValidProperty<string>("Телефон", phone, condition(phone));

        }

        public Client Safe()
        {
            try
            {
                return UnSafe();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public Client UnSafe()
        {
            validFirstName.Validate();
            validLastName.Validate();
            validPhone.Validate();
            return this;
        }
    }
}
