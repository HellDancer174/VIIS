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
        private ValidProperty<List<ServiceOfJournal>> validServices;
        private ValidProperty<Master> validMaster;
        private ClientOfJournal validClient;
        private List<ServiceOfJournal> servicesOfJournal;
        

        public OrderOfJournal(Order other) : base(other)
        {
            servicesOfJournal = services.Select(service => new ServiceOfJournal(service)).ToList();
            validSale = new ValidProperty<decimal>("Цена", sale, sale > 0);
            validStart = new ValidProperty<DateTime>("Дата и время заказа", ordersStart, ordersStart != new DateTime() && ordersStart.TimeOfDay != new TimeSpan());
            validServices = new ValidProperty<List<ServiceOfJournal>>("Услуги", servicesOfJournal, servicesOfJournal.Count != 0);
            validMaster = new ValidProperty<Master>("Мастер", master, master.IsWork(ordersStart.Date));
            validClient = new ClientOfJournal(person);
        }

        public Order Safe()
        {
            try
            {
                validClient.UnSafe();
                validMaster.Validate();
                validStart.Validate();
                validServices.Validate();
                servicesOfJournal.ForEach(service => service.UnSafe());
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
