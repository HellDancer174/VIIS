using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Finance.ViewModels;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Customers;
using VIIS.Domain.Finance;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIIS.Domain.Staff;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewNewOrderDetail : OrderDetailVM
    {
        public ViewNewOrderDetail(Master master, DateTime orderDate, Journal journal, ServiceValueList serviceValueList, Clients clients, ViewRepository<ViewTransaction, Transaction> transactions): 
            base(new Order(master, orderDate), journal, serviceValueList, clients, transactions)
        {

        }

        public override string SaveButtonName => "Добавить";
        public override string EndButtonName => "Отмена";

        //public override RelayCommand Save => new RelayCommand(async(obj) =>
        //{
        //    if (Price == 0) Price = ServicesPrice;
        //    sale = Price;
        //    var order = new Order(ClientNames.Model(), ViewServices.Select(viewService => new Service(viewService)).ToList(), master, comment, OrdersStart, sale);
        //    if (order.IsIncomplete) throw new InvalidOperationException(order.ToString());
        //    await journal.AddAsync(order);
        //});
        public override async Task SaveMethod(Order newOrder)
        {
            await journal.AddAsync(newOrder);
        }

        public override RelayCommand End => new RelayCommand((obj) => { });

        public override RelayCommand ExecuteOrderCommand => new RelayCommand((obj) =>
        {
            //await PostTransaction();
        }, (obj) => false);
    }
}
