using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.Models;
using VIIS.App.OrdersJournal.OrderDetail.Views.ClientNamePages;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Clients;
using VIIS.Domain.Orders;
using VIIS.Domain.Orders.Decorators;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class OrderDetailVM: OrderDecorator
    {
        private readonly PageTimes masterPage;
        private readonly ViewServiceValueList serviceValueList;

        public OrderDetailVM(Order order, PageTimes masterPage, ServiceValueList serviceValueList, Clients clients): base(order)
        {
            this.masterPage = masterPage;
            this.serviceValueList = new ViewServiceValueList(serviceValueList);
            ClientNames = new ViewClients(new ViewClient(client), new ExistingViewClient(clients));
            ViewServices = new ObservableCollection<ViewService>(services.Select(service => new ViewService(this.serviceValueList.ViewServices, service)));
            Sale = "0";

        }
        //public OrderDetailVM():this(new ViewClients(new NewClient(), new ExistingClient(), new ViewClient(), new ExistingViewClient()), DateTime.Now, new ObservableCollection<ViewService>(), string.Empty, new List<ViewServiceValue>())
        //{
        //}
        public ViewClients ClientNames { get; private set; }
        public DateTime OrdersDate => ordersDate;
        public ObservableCollection<ViewService> ViewServices { get; set; }
        public string Comment { get => comment; set => comment = value; }
        public string ServicesSale => ViewServices.Select(viewServices => viewServices.Sale).Sum().ToString();

        public string Sale { get; set; }

        public string SaveButtonName { get; private set; }
        public string EndButtonName { get; private set; }

        public RelayCommand Add => new RelayCommand((obl) => ViewServices.Add(new ViewService(serviceValueList.ViewServices, new Service(new ServiceValue()))));
        public RelayCommand Remove => new RelayCommand((obl) => 
        {
            if (ViewServices.Count == 0) return;
            else ViewServices.RemoveAt(ViewServices.Count - 1);
        });

        public virtual RelayCommand Save => new RelayCommand((obl) => throw new NotImplementedException());
        public virtual RelayCommand End => new RelayCommand((obl) => throw new NotImplementedException());

    }
}
