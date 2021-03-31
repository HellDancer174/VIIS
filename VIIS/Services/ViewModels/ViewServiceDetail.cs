using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.GlobalViewModel;
using VIIS.App.Services.Views;
using VIIS.Domain.Services;

namespace VIIS.App.Services.ViewModels
{
    public class ViewServiceDetail : ViewWindowDetail<ViewServices, ViewServiceValue, ServiceValue>
    {
        public ViewServiceDetail(ViewDetail<ViewServices, ViewServiceValue, ServiceValue> other) : base(other, new ServiceDetail())
        {
        }
        public ViewServiceDetail(ViewServices repo, ViewServiceValue selected): this(new ViewDetail<ViewServices, ViewServiceValue, ServiceValue>(repo, selected, new ViewServiceValue(selected)))
        {
        }
    }
}
