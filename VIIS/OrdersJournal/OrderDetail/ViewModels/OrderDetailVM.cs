using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    public class OrderDetailVM: OrderDecorator, INotifyPropertyChanged
    {
        protected readonly Journal journal;
        protected readonly Clients clients;
        //private readonly Window window;
        protected readonly ViewServiceValueList serviceValueList;

        public OrderDetailVM(Order order, Journal journal, ServiceValueList serviceValueList, Clients clients): base(order)
        {
            this.journal = journal;
            this.clients = clients;
            //this.window = window;
            this.serviceValueList = new ViewServiceValueList(serviceValueList);
            ClientNames = new ViewClients(new ViewClient(client), new ExistingViewClient(clients));
            ViewServices = new ObservableCollection<ViewService>(services.Select(service => new ViewService(this.serviceValueList.ViewServices, service, this)));
            Sale = sale.ToString();
        }

        public ViewClients ClientNames { get; private set; }
        public DateTime OrdersDate => ordersDate;
        public ObservableCollection<ViewService> ViewServices { get; set; }

        public string Comment { get => comment; set => comment = value; }

        public string ServicesSale => ViewServices.Select(viewServices => viewServices.Sale).Sum().ToString();
        public string Sale { get; set; }

        public virtual string SaveButtonName => "Сохранить";
        public virtual string EndButtonName => "Удалить";

        public RelayCommand Add => new RelayCommand((obl) => ViewServices.Add(new ViewService(serviceValueList.ViewServices, new Service(new ServiceValue()), this)));
        public RelayCommand Remove => new RelayCommand((obl) => 
        {
            if (ViewServices.Count == 0) return;
            else ViewServices.RemoveAt(ViewServices.Count - 1);
            ChangeProperty(nameof(ServicesSale));
        });

        public virtual RelayCommand Save => new RelayCommand(async(obl) =>
        {
            if (Convert.ToDecimal(Sale) == 0) Sale = ServicesSale;
            sale = Convert.ToDecimal(Sale);
            var newOrder = new Order(this);
            if (newOrder.IsIncomplete) throw new InvalidOperationException(newOrder.ToString());
            await journal.Update(other, this);
        });
        public virtual RelayCommand End => new RelayCommand(async(obl) =>
        {
            await journal.Remove(other);
        });

        public void ChangeServiceSale()
        {
            ChangeProperty(nameof(ServicesSale));
        }

    }
}
