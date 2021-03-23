using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VIIS.App.OrdersJournal.OrderDetail.Views.ClientNamePages;
using VIIS.Domain.Clients;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewClients: ViewModel<Client>
    {
        private readonly NewClient newClientPage;
        private readonly ExistingClient existingClientPage;
        private readonly ViewClient newClient;
        private readonly ExistingViewClient existingClient;

        public ViewClients(NewClient newClientPage, ExistingClient existingClientPage, ViewClient newClient, ExistingViewClient existingClient)
        {
            this.newClientPage = newClientPage;
            this.existingClientPage = existingClientPage;
            this.newClient = newClient;
            this.existingClient = existingClient;
        }
        //public Page Current { get; set; }
        public Page New => (Page)newClientPage;
        public Page Exist => (Page)existingClientPage;

        public override Client Model()
        {
            var anyClient = new AnyClient();
            var newModel = newClient.Model();
            var existingModel = existingClient.Model();
            if (newModel == anyClient && existingModel != anyClient) return existingModel;
            else if (newModel != anyClient && existingModel == anyClient) return newModel;
            else return anyClient;
        }

        //public RelayCommand WorkWithNewClient => new RelayCommand((obj) => Current = newClientPage);
        //public RelayCommand WorkWithExistingClient => new RelayCommand((obj) => Current = existingClientPage);

    }
}
