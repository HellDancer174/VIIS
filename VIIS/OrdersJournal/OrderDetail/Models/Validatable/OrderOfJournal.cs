using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.Domain.Global;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;

namespace VIIS.App.OrdersJournal.OrderDetail.Models.Validatable
{
    public class OrderOfJournal : OrderDecorator
    {
        private ValidProperty<DateTime> validStart;
        private ValidProperty<decimal> validSale;
        private ValidProperty<List<Service>> validServices;
        private ValidProperty<Master> validMaster;
        private ClientOfJournal validClient;
        

        public OrderOfJournal(Order other) : base(other)
        {
            validSale = new ValidProperty<decimal>("Цена", sale, sale > 0);
            validStart = new ValidProperty<DateTime>("Дата и время заказа", ordersStart, ordersStart != new DateTime());
            validServices = new ValidProperty<List<Service>>("Услуги", services, services.Count != 0);
            validMaster = new ValidProperty<Master>("Мастер", master, master.IsWork(ordersStart.Date));
            validClient = new ClientOfJournal(client);
        }

        public Order Safe()
        {
            try
            {
                validClient.UnSafe();
                validMaster.Validate();
                validStart.Validate();
                validServices.Validate();
                validSale.Validate();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return this;
        }
    }
}
