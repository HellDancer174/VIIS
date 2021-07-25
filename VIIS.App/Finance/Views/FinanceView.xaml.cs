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
using VIIS.App.Finance.ViewModels;

namespace VIIS.App.Finance.Views
{
    /// <summary>
    /// Логика взаимодействия для SettingsView.xaml
    /// </summary>
    public partial class FinanceView : Page
    {
        private readonly ViewTransactions viewModel;

        public FinanceView(ViewTransactions viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }
        public FinanceView(): this(new ViewTransactions())
        {
        }
    }
}
