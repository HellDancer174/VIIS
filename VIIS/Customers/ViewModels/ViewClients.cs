using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewClients : ViewRepository<ViewClient, Client>
    {
        //private int _selectedIndex;

        //private readonly ObservableCollection<ViewClient> clientCollection;

        public ViewClients(Clients other) : base(other, new ObservableCollection<ViewClient>(other.Select(client => new ViewClient(client)).ToList()))
        {
            //clientCollection = new ObservableCollection<ViewClient>(this.Select(client => new ViewClient(client, this)).ToList());
        }

        //public ObservableCollection<ViewClient> ClientCollection => clientCollection;


        public override ICommand AddCommand => new RelayCommand((obj) => new ViewWindowClientDetail(this));
        public override ICommand ChangeCommand => new RelayCommand((obj) => new ViewWindowClientDetail(new ViewClient(Selected), this));
        public override ICommand RemoveCommand => new RelayCommand(async (obj) =>
        {
            await RemoveViewAsync(Selected);
        });

        //public override Task UpdateViewAsync(ViewClient oldItem, ViewClient item)
        //{
        //    return base.UpdateViewAsync(oldItem, new ViewClient(item));
        //}

        //public int SelectedIndex
        //{ get => _selectedIndex;
        //    set => _selectedIndex = value;
        //}


        //public override Task AddAsync(Client item)
        //{
        //    ClientCollection.Add(new ViewClient(item, this));
        //    ChangeProperty(nameof(ClientCollection));
        //    return base.AddAsync(item);
        //}

        //public override Task RemoveAsync(Client item)
        //{
        //    ClientCollection.Remove(new ViewClient(item, this));
        //    ChangeProperty(nameof(Selected));
        //    ChangeProperty(nameof(ClientCollection));
        //    return base.RemoveAsync(item);
        //}

        //public Task UpdateView(ViewClient oldItem, ViewClient item)
        //{
        //    //var newClient = new ViewClient(item, this);
        //    //var index = ClientCollection.IndexOf(new ViewClient(oldItem, this));
        //    //ClientCollection[index] = newClient;
        //    ChangeProperty(nameof(ClientCollection));
        //    ChangeProperty(nameof(Selected));
        //    //ClientCollection[index].ChangeProperties();
        //    return Update(oldItem, item);
        //}

    }
}
