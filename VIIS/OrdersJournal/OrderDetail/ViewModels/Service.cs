using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class Service: ViewModel<string>
    {
        private readonly ObservableCollection<string> names;

        public Service(ObservableCollection<string> names)
        {
            this.names = names;
            Date = DateTime.Now.Date;
            Time = new TimeSpan();
            Period = new TimeSpan();
        }

        public ObservableCollection<string> Names => names;
        public string SelectedName { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan Period { get; set; }

        public RelayCommand Execute => new RelayCommand((obj) => throw new NotImplementedException(String.Format("NotImplemented property {0}", nameof(Execute))));

        public decimal Sale => 0;

    }
}
