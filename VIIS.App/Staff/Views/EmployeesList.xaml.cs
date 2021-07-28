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
using VIIS.Domain.Staff;

namespace VIIS.App.Staff.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeesList.xaml
    /// </summary>
    public partial class EmployeesList : Page
    {
        public EmployeesList(ViewEmployees masters)
        {
            InitializeComponent();
            DataContext = masters;
        }
        //public EmployeesList() : this(new ViewEmployees(new Employees(), (token) => App.Token = token))
        //{
        //}

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
