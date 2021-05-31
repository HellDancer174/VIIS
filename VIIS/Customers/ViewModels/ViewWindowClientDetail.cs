using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Customers.Models;
using VIIS.App.Customers.Views;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.OrderDetail.Models.Validatable;
using VIIS.Domain.Customers;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewWindowClientDetail : ViewWindowDetail<ViewClients, ViewClient, Client>
    {
        private readonly ViewDetail<ViewClients, ViewClient, Client> other;

        public ViewWindowClientDetail(ViewDetail<ViewClients, ViewClient, Client> other) : base(other, new CustomerDetailView())
        {
            this.other = other;
        }
        public ViewWindowClientDetail(ViewClient client, ViewClients clients): this(new ViewDetail<ViewClients, ViewClient, Client>(clients, client, new ViewClient(client)))
        {
        }
        public ViewWindowClientDetail(ViewClients clients) : this(new ViewNewDetail<ViewClients, ViewClient, Client>(clients, new ViewClient(), new ViewClient()))
        {
        }
        public override RelayCommand Save => new RelayCommand((obj) =>
        {
            try
            {
                new ClientOfCustomers(new ClientOfJournal(ViewModel.Model())).Safe();
            }
            catch (ArgumentException)
            {
                return;
            }
            base.Save.Execute(obj);
            //await repository.UpdateViewAsync(oldViewModel, new ViewClient(ViewModel.Model()));
            //ViewModel.NotifySelector();
        });

    }
}
