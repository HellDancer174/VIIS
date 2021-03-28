using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Customers.Views;
using VIIS.Domain.Customers;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewWindowClient: ViewClient
    {
        private readonly Window view;

        public ViewWindowClient(ViewClients clients) : this(new Client(), clients)
        {
        }

        public ViewWindowClient(ViewClient viewClient) : base(viewClient)
        {
            view = new CustomerDetailView(this);
            view.Show();
        }

        public ViewWindowClient(Client other, ViewClients clients) : base(other, clients)
        {
            view = new CustomerDetailView(this);
            view.Show();
        }

        public override RelayCommand Save => new RelayCommand((obj) => { base.Save.Execute(obj); view.Close(); });

        public override RelayCommand End => new RelayCommand((obj) => { base.End.Execute(obj); view.Close(); });
    }
}
