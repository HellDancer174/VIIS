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
    public class ViewServiceValueList : ServiceValueList
    {
        private readonly ServiceValueList other;

        public ViewServiceValueList(ServiceValueList other) : base(other)
        {
            this.other = other;
        }

        public List<ViewServiceValue> ViewServices => 
            new List<ViewServiceValue>(services.Select(service => new ViewServiceValue(service)).ToList());
    }
}
