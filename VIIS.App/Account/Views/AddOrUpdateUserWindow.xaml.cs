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
using VIIS.App.Account.ViewModels;

namespace VIIS.App.Account.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class AddOrUpdateUserWindow : Window
    {
        private IViewUserDetail userDetail;

        public AddOrUpdateUserWindow(IViewUserDetail userDetail)
        {
            InitializeComponent();
            DataContext = this.userDetail = userDetail;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await userDetail.Save(FPassword.Password, SPassword.Password);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
