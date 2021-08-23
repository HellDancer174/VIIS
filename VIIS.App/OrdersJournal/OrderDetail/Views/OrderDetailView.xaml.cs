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
        //private OrderDetailVM viewModel;
        public OrderDetailView()
        {
            InitializeComponent();
            Owner = App.Current.MainWindow;
            //DataContext = viewModel = new OrderDetailVM();
        }
        //public OrderDetailView(OrderDetailVM viewModel)
        //{
        //    InitializeComponent();
        //    DataContext = this.viewModel = viewModel;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void TabControl_Unselected(object sender, RoutedEventArgs e)
        //{
        //    //viewModel.ClientNames.Clear();
        //}

    }
}
