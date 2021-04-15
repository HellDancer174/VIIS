using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Customers.Views;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Customers;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewClientDetail : ViewDetail<ViewClients, ViewClient, Client>
    {
        public ViewClientDetail(ViewClients repository, ViewClient viewModel, ViewClient oldViewModel) : base(repository, viewModel, oldViewModel)
        {
        }

        public override RelayCommand Save => new RelayCommand(async (obj) => await repository.UpdateViewAsync(oldViewModel, new ViewClient(ViewModel)));
    }
}
