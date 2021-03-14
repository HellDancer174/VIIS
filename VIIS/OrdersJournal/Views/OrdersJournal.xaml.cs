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

namespace VIIS.App.OrdersJournal.Views
{
    /// <summary>
    /// Логика взаимодействия для OrdersJournal.xaml
    /// </summary>
    public partial class OrdersJournal : Window
    {
        public OrdersJournal()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            var list = new List<JournalTime>() { new JournalTime(8), new JournalTime(9), new JournalTime(10), new JournalTime(11), new JournalTime(12), new JournalTime(13), new JournalTime(14), new JournalTime(15), new JournalTime(16), new JournalTime(17), new JournalTime(18), new JournalTime(19) };

            JournalTimes content = new SafeJournalTimes(new JournalTimes(8, 20, list));
            content.AddContent(new JournalPageContent("Игнатьев В.А", "455476", "", new TimeSpan(9, 00, 0)));
            content.AddContent(new JournalPageContent("Игнатьев В.А", "455476", "", new TimeSpan(9, 30, 0)));

            DataContext = new JournalPage("Игнатьева В.И", content);
            
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
