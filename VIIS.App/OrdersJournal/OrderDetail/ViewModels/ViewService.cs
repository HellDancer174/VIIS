using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.Services.ViewModels;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class ViewService: BaseViewService
    {
        private ObservableCollection<ViewServiceValue> names;

        public ViewService(List<ServiceValue> serviceValues, Service other, OrderDetailVM orderDetail): this(serviceValues.Select(service => new ViewServiceValue(service)).ToList(), other, orderDetail)
        {
        }

        public ViewService(List<ViewServiceValue> serviceValues, Service other, OrderDetailVM orderDetail) : base(other)
        {
            this.orderDetail = orderDetail;
            this.names = new ObservableCollection<ViewServiceValue>(serviceValues);
            SelectedService = new ViewServiceValue(this);
        }
        public ViewService(List<ViewServiceValue> serviceValues, ViewService other, OrderDetailVM orderDetail) : base(other)
        {
            this.orderDetail = orderDetail;
            this.names = new ObservableCollection<ViewServiceValue>(serviceValues);
            SelectedService = new ViewServiceValue(this);
        }

        private ViewServiceValue selectedService;
        private readonly OrderDetailVM orderDetail;

        public ViewServiceValue SelectedService
        {
            get => selectedService;
            set
            {
                if (selectedService == value) return;
                selectedService = value;
                if(selectedService != null)
                {
                    name = selectedService.Name;
                    sale = selectedService.Sale;
                }
                ChangeProperty(nameof(SelectedService));
                orderDetail.ChangeServiceSale();
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
