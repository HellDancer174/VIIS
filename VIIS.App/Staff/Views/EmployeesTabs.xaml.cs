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
using VIIS.App.Staff.ViewModels;

namespace VIIS.App.Staff.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesTabs : Page
    {
        private readonly ViewEmployeesTabs viewModel;

        public EmployeesTabs(ViewEmployeesTabs viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }
    }
}
