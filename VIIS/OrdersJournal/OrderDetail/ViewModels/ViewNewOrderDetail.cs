using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Clients;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewNewOrderDetail : OrderDetailVM
    {
        public ViewNewOrderDetail(Master master, DateTime orderDate, Journal journal, ServiceValueList serviceValueList, Clients clients) : 
            base(new Order(master, orderDate), journal, serviceValueList, clients)
        {

        }

        public override string SaveButtonName => "Добавить";
        public override string EndButtonName => "Отмена";

        public override RelayCommand Save => new RelayCommand(async(obj) =>
        {
            if (Convert.ToDecimal(Sale) == 0) Sale = ServicesSale;
            sale = Convert.ToDecimal(Sale);
            var order = new Order(ClientNames.Model(), ViewServices.Select(viewService => new Service(viewService)).ToList(), master, comment, OrdersDate, sale);
            if (order.IsIncomplete) throw new InvalidOperationException(order.ToString());
            await journal.Add(order);
        });

        public override RelayCommand End => new RelayCommand((obj) => { });
    }
}
