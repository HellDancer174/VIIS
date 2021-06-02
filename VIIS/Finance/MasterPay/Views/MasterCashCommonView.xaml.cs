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
using VIIS.Domain.Finance;
using VIIS.Domain.Global;

namespace VIIS.App.Finance.MasterPay.Views
{
    /// <summary>
    /// Логика взаимодействия для MasterCashCommonView.xaml
    /// </summary>
    public partial class MasterCashCommonView : Page
    {
        private readonly ViewMasterCashList viewModel;

        public MasterCashCommonView(ViewMasterCashList viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }
        //public MasterCashCommonView(): this(new ViewMasterCashList(new Repository<MasterCash>(new List<MasterCash>())))
        //{
        //}

        
    }
}
