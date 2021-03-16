using ElegantLib.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using VIIS.App.OrdersJournal.ViewModels;
using VIIS.App.OrdersJournal.ViewModels.DecoratedJournalTimes;
using VIIS.App.OrdersJournal.ViewModels.Fake;
using VIIS.Domain.Orders;

namespace VIIS.App.OrdersJournal.Views
{
    /// <summary>
    /// Логика взаимодействия для OrdersJournal.xaml
    /// </summary>
    public partial class OrdersJournal : Window
    {
        private Journal journal;
        public OrdersJournal()
        {
            InitializeComponent();
            var orders = new Orders();
            DataContext = journal = new Journal(new ViewModels.Staff(new List<string>(), new List<string>(), new List<string>() { "Иванова И.И." }, new FakePage(new WorkDaysPage("", new Dictionary<string, ObservableCollection<PageTime>>())).Fake()), new Domain.Orders.Orders());
            journal.Staff.DaysPage.ChangePage("Иванова И.И.");
        }
    }
}
