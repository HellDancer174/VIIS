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
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class OrderDetailVM: ViewModel<Order>
    {
        private List<ViewServiceValue> viewServices;
        private DetailTransferableOrder order;
        private DateTime ordersDate;
        private readonly PageTimes page;

        public OrderDetailVM(ViewClients clientNames, DateTime ordersDate, ObservableCollection<ViewService> services, string comment, List<ViewServiceValue> viewServices)
        {
            ChangeContent(clientNames, ordersDate, services, comment, "Сохранить", "Удалить", viewServices);
            ViewServices.Add(new ViewService(new ObservableCollection<ViewServiceValue>(viewServices), new TimeSpan(), new TimeSpan()));
        }
        public OrderDetailVM(Order order,PageTimes page)
        {
            this.page = page;
            this.order = new DetailTransferableOrder(order, this, new Clients(), new ServiceValueList());
            order.Transfer();
        }
        public OrderDetailVM():this(new ViewClients(new NewClient(), new ExistingClient(), new ViewClient(), new ExistingViewClient()), DateTime.Now, new ObservableCollection<ViewService>(), string.Empty, new List<ViewServiceValue>())
        {
        }
        public void ChangeContent(ViewClients clientNames, DateTime ordersDate, ObservableCollection<ViewService> services, string comment, string saveButtonName, string endButtonName, List<ViewServiceValue> viewServices)
        {
            ClientNames = clientNames;
            this.ordersDate = ordersDate;
            ViewServices = services;
            Comment = comment;
            SaveButtonName = saveButtonName;
            EndButtonName = endButtonName;
            this.viewServices = viewServices;
        }
        public ViewClients ClientNames { get; private set; }
        public ObservableCollection<ViewService> ViewServices { get; set; }
        public string Comment { get; set; }
        public string Sale => ViewServices.Select(newSevices => newSevices.Sale).Sum().ToString();

        public string SaveButtonName { get; private set; }
        public string EndButtonName { get; private set; }

        public RelayCommand Add => new RelayCommand((obl) => ViewServices.Add(new ViewService(new ObservableCollection<ViewServiceValue>(viewServices), new TimeSpan(), new TimeSpan())));
        public RelayCommand Remove => new RelayCommand((obl) => 
        {
            if (ViewServices.Count == 0) return;
            var viewClient = new ViewClient(ClientNames.Model());
            var viewService = ViewServices.Last();
            page.RemoveContent(new PageViewService(viewClient.FullName, viewClient.Phone, viewService, viewService.Model(), order));
            ViewServices.RemoveAt(ViewServices.Count - 1);
            //Еще надо отправить запрос на сервер.
        });

        public virtual RelayCommand Save => new RelayCommand((obl) => throw new NotImplementedException());
        public virtual RelayCommand End => new RelayCommand((obl) => throw new NotImplementedException());

        public DateTime OrdersDate => ordersDate;
    }
}
