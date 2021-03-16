using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class OrderDetailVM: ViewModel<string>
    {
        //private List<string> serviceNames;
        private readonly List<string> servicesNames;

        public OrderDetailVM(ClientName clientName, ObservableCollection<Service> services, string comment, string sale, string saveButtonName, string endButtonName, List<string> servicesNames)
        {
            ClientName = clientName;
            Services = services;
            Comment = comment;
            Sale = sale;
            SaveButtonName = saveButtonName;
            EndButtonName = endButtonName;
            this.servicesNames = servicesNames;
            Services.Add(new Service(new ObservableCollection<string>(servicesNames)));

        }
        public OrderDetailVM():this(new ClientName(), new ObservableCollection<Service>(), string.Empty, "0", "Сохранить", "Удалить", new List<string>())
        {
        }

        public ClientName ClientName { get; }
        public ObservableCollection<Service> Services { get; set; }
        public string Comment { get; set; }
        public string Sale { get; set; }

        public string SaveButtonName { get; }
        public string EndButtonName { get; }

        public RelayCommand Add => new RelayCommand((obl) => Services.Add(new Service(new ObservableCollection<string>(servicesNames))));
        public RelayCommand Remove => new RelayCommand((obl) => { if (Services.Count == 0) return; Services.RemoveAt(Services.Count - 1); });

        public RelayCommand Save => new RelayCommand((obl) => throw new NotImplementedException());
        public RelayCommand End => new RelayCommand((obl) => throw new NotImplementedException());



    }
}
