using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.Models.OrdersDecorators;
using VIIS.App.Services.ViewModel;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewService: BaseViewService
    {
        private ObservableCollection<ViewServiceValue> names;

        public ViewService(List<ServiceValue> serviceValues, Service other): this(serviceValues.Select(service => new ViewServiceValue(service)).ToList(), other)
        {
        }

        public ViewService(List<ViewServiceValue> serviceValues, Service other) : base(other)
        {
            this.names = new ObservableCollection<ViewServiceValue>(serviceValues);
            SelectedService = new ViewServiceValue(this);

        }
        public ViewService(List<ViewServiceValue> serviceValues, ViewService other) : base(other)
        {
            this.names = new ObservableCollection<ViewServiceValue>(serviceValues);
            SelectedService = new ViewServiceValue(this);
        }

        private ViewServiceValue selectedService;
        public ViewServiceValue SelectedService
        {
            get => selectedService;
            set
            {
                selectedService = value;
                ChangeProperty(nameof(SelectedService));
            }
        }


        public ObservableCollection<ViewServiceValue> Names
        {
            get => names;
            set
            {
                names = value;
                ChangeProperty();
            }
        }

        public RelayCommand Execute => new RelayCommand((obj) => throw new NotImplementedException(String.Format("NotImplemented property {0}", nameof(Execute))));

    }
}
