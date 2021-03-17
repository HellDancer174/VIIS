using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VIIS.App.OrdersJournal.OrderDetail.Views.ClientNamePages;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ClientNames: ViewModel<string>
    {
        private readonly NewClient newClientPage;
        private readonly ExistingClient existingClientPage;

        public ClientNames(NewClient newClientPage, ExistingClient existingClientPage)
        {
            this.newClientPage = newClientPage;
            this.existingClientPage = existingClientPage;
        }
        //public Page Current { get; set; }
        public Page New => (Page)newClientPage;
        public Page Exist => (Page)existingClientPage;

        //public RelayCommand WorkWithNewClient => new RelayCommand((obj) => Current = newClientPage);
        //public RelayCommand WorkWithExistingClient => new RelayCommand((obj) => Current = existingClientPage);

    }
}
