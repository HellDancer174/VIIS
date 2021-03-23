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
        private readonly ObservableCollection<ViewServiceValue> names;

        public ViewService(ObservableCollection<ViewServiceValue> names, TimeSpan start, TimeSpan timeSpan): this(names, new Service(names.First().Model(), start, timeSpan), start, timeSpan)
        {
        }
        public ViewService(ObservableCollection<ViewServiceValue> names, Service current, TimeSpan start, TimeSpan timeSpan): base(current,  start, timeSpan)
        {
            SelectedService = new ViewServiceValue(current);
            this.names = names;
        }
        public ViewService(ObservableCollection<ViewServiceValue> names, Service current):this(names, current, new TimeSpan(), new TimeSpan())
        {
            current = new ViewTransferableService(current, this);
            current.Transfer();
        }

        public ObservableCollection<ViewServiceValue> Names => names;

        public RelayCommand Execute => new RelayCommand((obj) => throw new NotImplementedException(String.Format("NotImplemented property {0}", nameof(Execute))));

        public override decimal Sale => SelectedService.Sale;

    }
}
