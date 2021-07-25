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
using VIIS.App.Services.ViewModels;

namespace VIIS.App.Services.Views
{
    /// <summary>
    /// Логика взаимодействия для ServicesView.xaml
    /// </summary>
    public partial class ServicesView : Page
    {
        private ViewServices viewModel;

        public ServicesView(): this(new ViewServices())
        {
            //InitializeComponent();
            //DataContext = this.viewModel = new ViewServices();
        }
        public ServicesView(ViewServices viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }


    }
}
