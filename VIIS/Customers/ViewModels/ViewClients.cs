using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.Domain.Customers;
using VIIS.Domain.Customers.Decorators;
using VIMVVM;

namespace VIIS.App.Customers.ViewModels
{
    public class ViewClients : ClientsDecorator
    {
        private readonly ObservableCollection<ViewClient> clientCollection;

        public ViewClients(Clients other) : base(other)
        {
            clientCollection = new ObservableCollection<ViewClient>(this.Select(client => new ViewClient(client, this)).ToList());
        }

        public ObservableCollection<ViewClient> ClientCollection => clientCollection;

        public ViewClient Selected { get; set; }

        public RelayCommand AddCommand => new RelayCommand((obj) => new ViewWindowClient(new ViewNewClient(new ViewClient(new Client(), this, "Добавить", "Отмена"))));
        public RelayCommand ChangeCommand => new RelayCommand((obj) => new ViewWindowClient(Selected, this));
        public RelayCommand RemoveCommand => new RelayCommand(async (obj) =>
        {
            await RemoveAsync(Selected);
        });

        public override Task AddAsync(Client item)
        {
            ClientCollection.Add(new ViewClient(item, this));
            ChangeProperty(nameof(ClientCollection));
            return base.AddAsync(item);
        }

        public override Task RemoveAsync(Client item)
        {
            ClientCollection.Remove(new ViewClient(item, this));
            ChangeProperty(nameof(Selected));
            ChangeProperty(nameof(ClientCollection));
            return base.RemoveAsync(item);
        }

        public override Task Update(Client oldItem, Client item)
        {
            ClientCollection[ClientCollection.IndexOf(new ViewClient(oldItem, this))] = new ViewClient(item, this);
            ChangeProperty(nameof(Selected));
            ChangeProperty(nameof(ClientCollection));
            return base.Update(oldItem, item);
        }

    }
}
