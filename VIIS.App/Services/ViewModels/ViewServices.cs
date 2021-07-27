using ElegantLib.Authorize.Tokenize;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIIS.App.GlobalViewModel;
using VIIS.Domain.Account;
using VIIS.Domain.Global;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.Services.ViewModels
{
    public class ViewServices : ViewUpdatableRepository<ViewServiceValue, ServiceValue>
    {
        public ViewServices(Repository<ServiceValue> other, Action<RefreshViewModel> saveToken) : base(other, saveToken, (service) => new ViewServiceValue(service), new VIISJwtURL().ServiceValuesUrl)
        {
        }
        public ViewServices() : this(new ServiceValueList(), (token) => App.Token = token)
        {
        }

        public override ICommand AddCommand => new RelayCommand((obj) => new ViewNewServiceDetail(this));

        public override ICommand ChangeCommand => new RelayCommand((obj) => new ViewServiceDetail(this, new ViewServiceValue(Selected)));

        public override ICommand RemoveCommand => new RelayCommand(async(obj) => await RemoveViewAsync(Selected));
    }
}
