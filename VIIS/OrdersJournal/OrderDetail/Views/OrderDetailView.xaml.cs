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
using System.Windows.Shapes;
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;

namespace VIIS.App.OrdersJournal.OrderDetail.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderDetail.xaml
    /// </summary>
    public partial class OrderDetailView : Window
    {
        private OrderDetailVM viewModel;
        public OrderDetailView()
        {
            InitializeComponent();
            //DataContext = viewModel = new OrderDetailVM();
        }
        public OrderDetailView(OrderDetailVM viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }
    }
}
