using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.Views.ClientNamePages;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class OrderDetailVM: ViewModel<string>
    {
        private readonly List<string> servicesNames;

        public OrderDetailVM(ClientNames clientNames, ObservableCollection<Service> services, string comment, string sale, string saveButtonName, string endButtonName, List<string> servicesNames)
        {
            ClientNames = clientNames;
            Services = services;
            Comment = comment;
            Sale = sale;
            SaveButtonName = saveButtonName;
            EndButtonName = endButtonName;
            this.servicesNames = servicesNames;
            Services.Add(new Service(new ObservableCollection<string>(servicesNames)));

        }
        public OrderDetailVM():this(new ClientNames(new NewClient(), new ExistingClient()), new ObservableCollection<Service>(), string.Empty, "0", "Сохранить", "Удалить", new List<string>())
        {
        }

        public ClientNames ClientNames { get; }
        public ObservableCollection<Service> Services { get; set; }
        public string Comment { get; set; }
        public string Sale { get; set; }

        public string SaveButtonName { get; }
        public string EndButtonName { get; }

        public RelayCommand Add => new RelayCommand((obl) => Services.Add(new Service(new ObservableCollection<string>(servicesNames))));
        public RelayCommand Remove => new RelayCommand((obl) => { if (Services.Count == 0) return; Services.RemoveAt(Services.Count - 1); });

        public virtual RelayCommand Save => new RelayCommand((obl) => throw new NotImplementedException());
        public virtual RelayCommand End => new RelayCommand((obl) => throw new NotImplementedException());



    }
}
