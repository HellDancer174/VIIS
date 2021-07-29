using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VIIS.App.Finance.ViewModels;
using VIIS.App.GlobalViewModel;
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.Domain.Customers;
using VIIS.Domain.Finance;
using VIIS.Domain.Orders;
using VIIS.Domain.Services;
using VIMVVM;

namespace VIIS.App.OrdersJournal.OrderDetail.ViewModels
{
    public class WindowOrderDetail : OrderDetailVM
    {
        private readonly OrderDetailVM otherDetail;
        private readonly Window view;

        public WindowOrderDetail(OrderDetailVM other, Window view) : base(other)
        {
            this.otherDetail = other;
            this.view = view;
            view.DataContext = this;
            view.Show();
        }

        public override RelayCommand End => new RelayCommand((obj) => { otherDetail.End.Execute(obj); view.Close(); });

        public override string SaveButtonName => otherDetail.SaveButtonName;

        public override string EndButtonName => otherDetail.EndButtonName;

        public override RelayCommand ExecuteOrderCommand => new RelayCommand((obj) => { isFinished = true; Save.Execute(obj); otherDetail.ExecuteOrderCommand.Execute(obj); }, otherDetail.ExecuteOrderCommand.CanExecute);

        public override async Task SaveMethod(Order newOrder)
        {
            await otherDetail.SaveMethod(newOrder);
            view.Close();
        }
    }
}
