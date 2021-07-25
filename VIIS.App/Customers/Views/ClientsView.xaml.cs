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
using VIIS.App.Customers.ViewModels;

namespace VIIS.App.Customers.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsView.xaml
    /// </summary>
    public partial class ClientsView : Page
    {
        private readonly ViewClients viewModel;

        public ClientsView(): this(new ViewClients(new Domain.Customers.Clients()))
        {
            InitializeComponent();
        }

        public ClientsView(ViewClients viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }
    }
}
