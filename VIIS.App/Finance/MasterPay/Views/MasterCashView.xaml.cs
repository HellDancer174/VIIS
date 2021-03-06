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
using VIIS.App.Finance.MasterPay.ViewModels;

namespace VIIS.App.Finance.MasterPay.Views
{
    /// <summary>
    /// Логика взаимодействия для MasterCashView.xaml
    /// </summary>
    public partial class MasterCashView : Page
    {
        private readonly ViewAdditionalMasterCashList viewModel;

        public MasterCashView(ViewAdditionalMasterCashList viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }
    }
}
