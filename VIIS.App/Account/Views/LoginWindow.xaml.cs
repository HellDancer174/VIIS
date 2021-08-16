using ElegantLib.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using VIIS.App.Account.Models;
using VIIS.App.Account.ViewModels;
using VIIS.Domain.Account;

namespace VIIS.App.Account.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IViewLogin viewLogin;

        //public LoginWindow(LoginViewModel viewModel)
        //{
        //    InitializeComponent();
        //    DataContext = viewModel;
        //    viewLogin = viewModel;
        //}
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = viewLogin = new LoginViewModel(new MemoryJwtAccount(new HttpClient(), new VIISJwtURL(), (token) => App.Token = token), this);
        }
        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Minimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            await viewLogin.LogIn(SecretPass.Password);
        }
    }
}
