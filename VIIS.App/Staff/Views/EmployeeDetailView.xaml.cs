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
using VIIS.App.Staff.ViewModels;
using VIIS.Domain.Staff;

namespace VIIS.App.Staff.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeeDetail.xaml
    /// </summary>
    public partial class EmployeeDetailView : Window
    {
        //private readonly ViewEmployee employee;

        public EmployeeDetailView()
        {
            InitializeComponent();
        }
        //public EmployeeDetailView(ViewEmployee employee)
        //{
        //    InitializeComponent();
        //    DataContext = this.employee = employee;
        //}
    }
}
