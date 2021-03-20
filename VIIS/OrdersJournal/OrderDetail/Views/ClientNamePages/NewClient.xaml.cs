﻿using System;
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
using VIIS.App.OrdersJournal.OrderDetail.ViewModels;

namespace VIIS.App.OrdersJournal.OrderDetail.Views.ClientNamePages
{
    /// <summary>
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
    public partial class NewClient : Page
    {
        private ClientName clientName;
        public NewClient():this(new ClientName())
        {
        }
        public NewClient(ClientName clientName)
        {
            InitializeComponent();
            DataContext = this.clientName = clientName;
        }
    }
}