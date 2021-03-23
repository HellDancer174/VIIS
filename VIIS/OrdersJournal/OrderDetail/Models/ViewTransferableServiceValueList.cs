using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;
using VIIS.Domain.Services;

namespace VIIS.App.OrdersJournal.OrderDetail.Models
{
    public class ViewTransferableServiceValueList : ServiceValueList
    {
        private readonly ServiceValueList other;

        public ViewTransferableServiceValueList(ServiceValueList other) : base(other)
        {
            this.other = other;
        }

        public ObservableCollection<ViewServiceValue> ViewServices => 
            new ObservableCollection<ViewServiceValue>(services.Select(service => new ViewServiceValue(service)).ToList());
    }
}
