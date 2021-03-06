using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VIIS.App.Staff.ViewModels.PayViewModels;
using VIIS.Domain.Staff;

namespace VIIS.App.Staff.Views
{
    /// <summary>
    /// Логика взаимодействия для PayView.xaml
    /// </summary>
    public partial class PayView : Page
    {
        private readonly ViewMastersCashList viewModel;

        public PayView(ViewMastersCashList viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }
        public PayView(): this(new ViewMastersCashList(new Domain.Staff.Employees(), new Domain.Orders.Orders(new Master())))
        {
        }

        private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            Calendar.DisplayMode = CalendarMode.Year;
        }

    }
}
