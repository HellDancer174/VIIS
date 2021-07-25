using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Services;

namespace VIIS.App.Services.ViewModels
{
    public class ViewNewServiceDetail : ViewServiceDetail
    {
        public ViewNewServiceDetail(ViewServices repo) : base(new ViewNewDetail<ViewServices, ViewServiceValue, ServiceValue>(repo, new ViewServiceValue(), new ViewServiceValue()))
        {
        }
    }
}
